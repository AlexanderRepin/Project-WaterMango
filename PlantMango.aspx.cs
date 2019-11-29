using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Threading;

namespace Project_WaterMango
{
    public partial class PlantMango : System.Web.UI.Page
    {
        bool buttonClicked;
        bool doneWatering;
        int dateResult;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Check if the page is loading for the first time or not
            if (!Page.IsPostBack)
            {
                Thread thread1 = new Thread(checkingTime);
                
                PlantGrid();
                thread1.Start();

            }

            DateTime currDate = DateTime.Now;
            DateTime futureDate = DateTime.Now.AddHours(6);

            dateResult = DateTime.Compare(currDate, futureDate);

            if (dateResult < 0)
            {
                // Do nothing
            }
            else
            {
                // Label will alert the user to water the plant
                lblTimeWatered.Visible = true;
            }

        }
        private void PlantGrid()
        {
            // Sample data used and manually entered
            
            lblTimeWatered.Visible = false;
            buttonClicked = false;
            

            DataTable dt = new DataTable();

            dt.Columns.Add("Plant ID", typeof(string));
            dt.Columns.Add("Plant Name", typeof(string));
            dt.Columns.Add("Plant Status", typeof(string));
            dt.Columns.Add("Plant Command", typeof(string));

            DataRow plant1 = dt.NewRow();
            DataRow plant2 = dt.NewRow();
            DataRow plant3 = dt.NewRow();
            DataRow plant4 = dt.NewRow();
            DataRow plant5 = dt.NewRow();

            plant1["Plant ID"] = "1";
            plant1["Plant Name"] = "Christmas Cactus";
            plant1["Plant Status"] = "Unwatered";
            plant1["Plant Command"] = "None";

            dt.Rows.Add(plant1);

            plant2["Plant ID"] = "2";
            plant2["Plant Name"] = "Fern";
            plant2["Plant Status"] = "Unwatered";
            plant2["Plant Command"] = "None";

            dt.Rows.Add(plant2);

            plant3["Plant ID"] = "3";
            plant3["Plant Name"] = "Indoor Palm";
            plant3["Plant Status"] = "Unwatered";
            plant3["Plant Command"] = "None";

            dt.Rows.Add(plant3);

            plant4["Plant ID"] = "4";
            plant4["Plant Name"] = "Lucky Bamboo";
            plant4["Plant Status"] = "Unwatered";
            plant4["Plant Command"] = "None";

            dt.Rows.Add(plant4);

            plant5["Plant ID"] = "5";
            plant5["Plant Name"] = "Venus Fly Trap";
            plant5["Plant Status"] = "Unwatered";
            plant5["Plant Command"] = "None";

            dt.Rows.Add(plant5);

            PlantGridView.DataSource = dt;
            PlantGridView.DataBind();

        }


        private void watering(GridViewRow gvRow)
        {
            // Changing the state of the Plant as the user 'waters' the plant
            Label plantCommand = gvRow.FindControl("plantCommand") as Label;
            Label plantStatus = gvRow.FindControl("plantStatus") as Label;
            Button btnSubmit = gvRow.FindControl("btnSubmit") as Button;
    

            if (gvRow.RowType == DataControlRowType.DataRow)
            {
                System.Threading.Thread.Sleep(1000);

                if (plantCommand.Text == "None")
                {
                    plantCommand.Text = "";
                    plantStatus.Text = "Watering...";
                    
                    btnSubmit.Text = "Finish Watering";
                }
                

                else if (plantCommand.Text == "")
                {
                    // Waiting 10 seconds to water the plant
                    System.Threading.Thread.Sleep(10000);
                    plantStatus.Text = "Watered";                  

                }
                
                if (plantStatus.Text == "Watered" && plantCommand.Text == "")
                {
                    plantCommand.Text = "Cannot Water...";
                    btnSubmit.Text = "Waiting";
                }
                else if(plantCommand.Text == "Cannot Water...")
                {
                    // waiting 30 seconds
                    System.Threading.Thread.Sleep(30000);
                    plantCommand.Text = "Can water again...";
                    btnSubmit.Text = "Water Plant";
                    doneWatering = true;
                   
                }

            }
        }

        protected void waterButtonClick(object sender, EventArgs e)
        {
            // Get the current row for the button pressed
            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;

            Label plantCommand = gvRow.FindControl("plantCommand") as Label;

            buttonClicked = true;
            watering(gvRow);

            if (doneWatering)
                plantCommand.Text = "None";

        }

        private void checkingTime()
        {
            // If the time watered + 6 hours is greater than current time 'plant needs to be watered'
            // 1000 ms * 60 seconds * 60 minutes * 6 hours
            //System.Threading.Thread.Sleep(21600000);
            System.Threading.Thread.Sleep(2000); // Test for 2 seconds

            lblTimeWatered.Visible = true;

 
        }


        protected void PlantGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if(e.Row.RowType == DataControlRowType.DataRow && buttonClicked)
            {
                Label plantCommand = e.Row.FindControl("plantCommand") as Label;

                plantCommand.Text = "Watering...";
            }
        }
    }
}