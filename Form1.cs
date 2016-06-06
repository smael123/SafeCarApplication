using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Net;

namespace SafeCarApplication
{
    public partial class Form1 : Form
    {
        List<int> yearList;
        List<string> makeList;
        List<string> modelList;
        Dictionary<string, int> variantDict;

        int desiredYear;
        string desiredMake;
        string desiredModel;
        int desiredVehicleId;

        //sorry i forgot to ALL CAPS these variable names
        const string apiUrl = "http://www.nhtsa.gov/webapi/api/SafetyRatings"; 
        const string outputFormat = "?format=json";


        public Form1()
        {
            InitializeComponent();
            cmbMake.Enabled = false;
            cmbModel.Enabled = false;
            lstBxVariant.Enabled = false;
            populateYearBox();    
        }

        private JSON_Root getResponse(string apiParam)
        {

            WebClient client = new WebClient();
            string json = client.DownloadString(apiUrl + apiParam + outputFormat);
            JSON_Root root = JsonConvert.DeserializeObject<JSON_Root>(json);
            return root;
        }
        private void createYearList(JSON_Root root)
        {
            yearList = root.getYears();
        }
        private void createMakeList(JSON_Root root)
        {
            makeList = root.getMakes();
        }
        private void createModelList(JSON_Root root)
        {
            modelList = root.getModels();
        }
        private void createVariantDict(JSON_Root root)
        {
            variantDict = root.getVariants();
        }
        public void populateYearBox()
        {
            try
            {
                createYearList(getResponse(""));
                foreach (int year in yearList)
                    cmbYear.Items.Add(year);
            }
            catch (System.Net.WebException web)
            {
                MessageBox.Show("It seems that you are not connected to the internet.\nPlease connect and start this program again.");
                Application.Exit();
            }
           
        }
        public void populateMakeBox()
        {
            createMakeList(getResponse("/modelyear/" + desiredYear.ToString()));
            foreach (string make in makeList)
                cmbMake.Items.Add(make);
        }
        public void populateModelBox()
        {
            createModelList(getResponse("/modelyear/" + desiredYear.ToString() + "/make/" + desiredMake));
            foreach (string model in modelList)
                cmbModel.Items.Add(model);
        }
        public void populateVariantBox()
        {
            createVariantDict(getResponse("/modelyear/" + desiredYear.ToString() + "/make/" + desiredMake + "/model/" + desiredModel));
            foreach (string key in variantDict.Keys)
            {
                //MessageBox.Show(key);
                lstBxVariant.Items.Add(key);
            }
                
        }

        private void lstBxVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            if (variantDict.TryGetValue(lstBxVariant.Text, out id))
                desiredVehicleId = id;
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            desiredYear = Int32.Parse(cmbYear.Text);
            populateMakeBox();
            cmbMake.Enabled = true;
        }

        private void cmbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            desiredMake = cmbMake.Text;
            populateModelBox();
            cmbModel.Enabled = true;
        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            desiredModel = cmbModel.Text;
            populateVariantBox();
            lstBxVariant.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbYear.Items.Clear();
            cmbMake.Items.Clear();
            cmbModel.Items.Clear();
            lstBxVariant.Items.Clear();

            cmbYear.ResetText();
            cmbMake.ResetText();
            cmbModel.ResetText();

            cmbMake.Enabled = false;
            cmbModel.Enabled = false;
            lstBxVariant.Enabled = false;
            populateYearBox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            JSON_Root obj = getResponse("/VehicleId/" + desiredVehicleId.ToString());
            Vehicle veh = obj.getResult();
            MessageBox.Show(veh.ToString());
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            str.Append("Safe Car Application Version 1.0");
            str.Append("Created by Ismael Almaguer\n ismael.alma@gmail.com");
            str.Append("This application parses JSON data from the NHTSA New Car Assesment Program API");
            str.Append("All vehicles parsed have recieved a five star saftey rating.");
            str.Append("Icon image from pixabay.com");
            MessageBox.Show(str.ToString());
        }
    }
    
}
