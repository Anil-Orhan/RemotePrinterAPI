using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using RawPrint;
using RawPrint.NetStd;

namespace ClientSocket
{
    public partial class Form1 : Form
    {
        private string str = "";
        private string filePath;
        private string fileName;
        private string printerName;
        IHubProxy _hubProxy;
        public Form1()
        {
           
            InitializeComponent();
            
           
          

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        { // Create an instance of the Printer
            IPrinter printer = new Printer();
            // Print the file
            printer.PrintRawFile(printerName, filePath, fileName);
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {


            var saveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Files");
            using (var openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    File.Copy(openFileDialog1.FileName,Path.Combine(@"C:\Users\Vodases\source\repos\UploadPrj\ClientSocket\Files",
                        Path.GetFileName(openFileDialog1.SafeFileName)),true);


                    fileName = Path.GetFileName(openFileDialog1.FileName);
                    var fileSavePath = Path.Combine(saveDirectory, fileName);
                    //File.Copy(openFileDialog1.FileName, fileSavePath, true);
                    str = fileSavePath;
                    MessageBox.Show("Dosya Yüklendi");
                   
                }
            }
            filePath = str;
           
            printerName = "LBP653C/654C";
        }
        public void Send(string file)
        {
            using (var process = new Process())
            {
                process.StartInfo.FileName = @"C:\Users\Vodases\source\repos\UploadPrj\clientsocket\bin\Debug\ClientSocket.exe";
                process.StartInfo.Arguments = $"{file}";
                //process.StartInfo.FileName = @"cmd.exe";
                //process.StartInfo.Arguments = @"/c dir";     
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;

                process.OutputDataReceived += (sender, data) => Console.WriteLine(data.Data);
                process.ErrorDataReceived += (sender, data) => Console.WriteLine(data.Data);
                Console.WriteLine("starting");
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                var exited = process.WaitForExit(1000 * 10);
                Console.WriteLine($"exit {exited}");


            }
            printDocument1.Print();
            // Clients.All.SendAsync("OnMessage", file);
        }

     

        private void btnSend_Click(object sender, EventArgs e)
        {


            printDocument1.Print();

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
