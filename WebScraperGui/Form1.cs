using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebScraperGui.Configuration;
using WebScraperGui.Custom_Model;
using Trendyol = WebScraperGui.Trendyol;
using N11 = WebScraperGui.n11;
using Amazon = WebScraperGui.Amazon;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;


namespace WebScraperGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }
        public int selectedItemsCount = 0;
        public decimal totalTLBuyingPrice = 0;
        public string searchText = "";
        public List<CustomModel> alllist = new List<CustomModel>();
        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }
        private async void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

           Process(worker).Wait();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_process.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Hata oluştu: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                MessageBox.Show("İşlem iptal edildi.");
            }
            else
            {
     
                MessageBox.Show("İşlem tamamlandı.");
            }
        }
        private async void button_start_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                progressBar_process.Value = 0;
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                // Eğer işlem devam ediyorsa, iptal et
                backgroundWorker.CancelAsync();
            }
        }
        public async Task Process(BackgroundWorker worker)
        {
            searchText = $"{textBox_productname.Text} {textBox_productbrand.Text} {textBox_productmodel.Text}";
            if (string.IsNullOrEmpty(searchText)) { MessageBox.Show("Aranacak ürünü girmediniz."); }
            else
            {


                string profiletest = textBox_profilepath.Text;

                var newconfig = new WebDriverConfiguration(selectedItemsCount, profiletest);

                var driver = newconfig.GetDriver();

                var totalTasks = new List<Task<List<CustomModel>>>();

                // Task'ları oluştur

                var i = 0;
                // Seçili öğe var mı kontrol et
                if (checkedListBox_ecommerce.CheckedIndices.Count > 0)
                {
                    // En üstteki seçili öğeyi al (varsayılan olarak sadece bir öğe seçilebilir)
                    foreach (var selectedItem in checkedListBox_ecommerce.CheckedItems)
                    {
                        int selectedKey = ((KeyValuePair<int, string>)selectedItem).Key;

                        switch (selectedKey)
                        {
                            case 1:
                                totalTasks.Add(ProcessTrendyolAsync(driver[i], searchText));
                                i++;
                                break;
                            case 2:
                                totalTasks.Add(ProcessN11Async(driver[i], searchText));
                                i++;
                                break;
                            case 3:
                                totalTasks.Add(ProcessAmazonAsync(driver[i], searchText));
                                i++;
                                break;
                            default:
                                i = 0;
                                break;
                        }
                    }
                }

                var completedTasks = 0;
                await Task.WhenAll(totalTasks);
                foreach (var task in totalTasks)
                {

                    while (!task.IsCompleted)
                    {
                        // İşlemi bir süre bekletin ve ardından kontrolü tekrarlayın
                        await Task.Delay(1000);
                    }

                    List<CustomModel> result = await task;

                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        alllist.AddRange(result);
                    }

                    completedTasks++;
                    int progressPercentage = (int)((float)completedTasks / totalTasks.Count * 100);
                    //
                    Invoke((MethodInvoker)delegate
                    {
                        label_progress.Text = progressPercentage.ToString();
                        worker.ReportProgress(progressPercentage);
                    });
                   

                }


                
            }

            string jsonText = JsonConvert.SerializeObject(alllist, Newtonsoft.Json.Formatting.Indented);

            foreach (var item in alllist)
            {
                try
                {
               

                    if (item.BuyingPrice.Contains("TL"))
                    {
                        totalTLBuyingPrice+=  decimal.Parse(item.BuyingPrice.Trim().Replace("TL", ""));
                    }
                    else if (item.BuyingPrice.Contains("$"))
                    {
                        totalTLBuyingPrice+= decimal.Parse(item.BuyingPrice.Replace("$", "")) * 30;
                    }
                }
                catch (FormatException ex)
                {
                    // Decimal.Parse sırasında hata oluştuğunda buraya düşer
                    Console.WriteLine($"Hata: {ex.Message}");
                    // Burada hatanın hangi öğe üzerinde oluştuğunu da yazdırabilirsiniz
                    Console.WriteLine($"Hata Oluşan Öğe: {item}");
                }
            }

  //          decimal totalTLBuyingPrice = alllist
  // .Where(x => !string.IsNullOrWhiteSpace(x.BuyingPrice) && !x.BuyingPrice.Contains("$"))
  // .Select(x => decimal.Parse(x.BuyingPrice.Trim().Replace("TL", "")))
  // .Sum();
  //          decimal totaldolar = alllist
  //.Where(x => !string.IsNullOrWhiteSpace(x.BuyingPrice) && x.BuyingPrice.Contains("$"))
  //.Select(x => decimal.Parse(x.BuyingPrice.Replace("$", "")))
  //.Sum();
            
            string totalBuyingPriceAsString = totalTLBuyingPrice.ToString();
            Invoke((MethodInvoker)delegate
            {
                label_productcount.Text = alllist.Count().ToString();
                label_productamount.Text = totalBuyingPriceAsString + " TL";
                label_terim.Text = searchText;
            });


            File.WriteAllText("txt.json", jsonText);
            MessageBox.Show(Path.Combine(Directory.GetCurrentDirectory(), "txt.json"));
            // Diğer işlemleri gerçekleştir
            // ...
        }
        public static async Task<List<CustomModel>> ProcessTrendyolAsync(ChromeDriver driver, string query)
        {
            var trendyol = new Trendyol.DataProcess(driver);
            return await trendyol.Process(query);
        }

        public static async Task<List<CustomModel>> ProcessN11Async(ChromeDriver driver, string query)
        {
            var n11 = new N11.DataProcess(driver);
            return await n11.Process(query);
        }

        public static async Task<List<CustomModel>> ProcessAmazonAsync(ChromeDriver driver, string query)
        {
            var amazon = new Amazon.DataProcess(driver);
            return await amazon.Process(query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            checkedListBox_ecommerce.DisplayMember = "Value";
            checkedListBox_ecommerce.Items.Add(new KeyValuePair<int, string>(1, "Trendyol"));
            checkedListBox_ecommerce.Items.Add(new KeyValuePair<int, string>(2, "N11"));
            checkedListBox_ecommerce.Items.Add(new KeyValuePair<int, string>(3, "Amazon"));
            for (int i = 0; i < checkedListBox_ecommerce.Items.Count; i++)
            {
                checkedListBox_ecommerce.SetItemChecked(i, true);
            }
            selectedItemsCount = checkedListBox_ecommerce.CheckedItems.Count;

           
            checkedListBox_ecommerce.ItemCheck += checkedListBox_ecommerce_ItemCheck;

            Console.WriteLine($"Seçili öğe sayısı: {selectedItemsCount}");
        }

        private void checkedListBox_ecommerce_ItemCheck(object sender, EventArgs e)
        {
            
           
        }

        private void checkedListBox_ecommerce_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItemsCount = checkedListBox_ecommerce.CheckedItems.Count;
            Console.WriteLine($"Seçili öğe sayısı: {selectedItemsCount}");
        }
    }
}
