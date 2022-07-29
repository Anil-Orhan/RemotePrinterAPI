using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using RawPrint;
using RawPrint.NetStd;


namespace ClientSocket
{
    public partial class Form1 : Form
    {
        private string str = "";
        private string filePath;
        private string fileName;
        private string printerName="Canon Generic Plus PS3";
        IHubProxy _hubProxy;
        private string lastPath;

        public Form1()
        {

            InitializeComponent();

            GetLastFileLocation();
            


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        { // Create an instance of the Printer

        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {


            var saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");
            using (var openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    File.Copy(openFileDialog1.FileName, Path.Combine(@"C:\Users\Vodases\Desktop\PrintOmiGuncel\backend\ClientSocket\Files",
                        Path.GetFileName(openFileDialog1.SafeFileName)), true);


                    fileName = Path.GetFileName(openFileDialog1.FileName);
                    var fileSavePath = Path.Combine(saveDirectory, fileName);
                    //File.Copy(openFileDialog1.FileName, fileSavePath, true);
                    str = fileSavePath;
                    MessageBox.Show("Dosya Yüklendi");

                }
            }
            filePath = str;

            printerName = "Canon Generic Plus PS3";
        }
        //public void Send(string file)
        //{
        //    using (var process = new Process())
        //    {
        //        process.StartInfo.FileName = @"C:\Users\Vodases\Desktop\PrintOmiGuncel\backend\ClientSocket\bin\Debug\ClientSocket.exe";
        //        process.StartInfo.Arguments = $"{file}";
        //        //process.StartInfo.FileName = @"cmd.exe";
        //        //process.StartInfo.Arguments = @"/c dir";     
        //        process.StartInfo.CreateNoWindow = true;
        //        process.StartInfo.UseShellExecute = false;
        //        process.StartInfo.RedirectStandardOutput = true;
        //        process.StartInfo.RedirectStandardError = true;

        //        process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
        //        process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
        //        Console.WriteLine("starting");
        //        process.Start();
        //        process.BeginOutputReadLine();
        //        process.BeginErrorReadLine();
        //        var exited = process.WaitForExit(1000 * 10);
        //        Console.WriteLine($"exit {exited}");


        //    }
        //    printDocument1.Print();
        //    // Clients.All.SendAsync("OnMessage", file);
        //}

     
        public async Task<string> GetLastFileLocation()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7106/");
            HttpResponseMessage response = await client.GetAsync("api/File/getlastfile");
            HttpResponseMessage responseName = await client.GetAsync("api/File/getlastfilename");
            var result=await response.Content.ReadAsStringAsync();
            var result2 = await responseName.Content.ReadAsStringAsync();
            
            label1.Text= result.ToString();
            fileName = result2.ToString();
            lastPath=result.ToString();
            return result;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            GetLastFileLocation();

            IPrinter printer = new Printer();
            // Print the file
            if (lastPath!=null)

            {
               

                printer.PrintRawFile(printerName, lastPath, "deneme.pdf");
            }
            else
            {
                MessageBox.Show("Bulunamadı!");
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void HubConnection_StateChanged(StateChange obj)
        {
            if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                writeToLog("Connected");
            else if (obj.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected)
                writeToLog("Disconnected");
        }

        private void writeToLog(string log)
        {
            if (this.InvokeRequired)
                this.BeginInvoke(new Action(() => MessageBox.Show(log + Environment.NewLine)));
           
        }
    }


}
