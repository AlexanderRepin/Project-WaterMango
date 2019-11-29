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
        int count = 0;
        Label timer = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
                PlantGrid();
        }
        private void PlantGrid()
        {

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
            if (gvRow.RowType == DataControlRowType.DataRow)
            {
                Label plantCommand = gvRow.FindControl("plantCommand") as Label;
                Label plantStatus = gvRow.FindControl("plantStatus") as Label;

                //do what ever you want to do here with the label
                plantCommand.Text = "Watering...";

                System.Threading.Thread.Sleep(10000);

                plantCommand.Text = "";
                plantStatus.Text = "Watered";

            }
        }

        protected void waterButtonClick(object sender, EventArgs e)
        {
            foreach(GridViewRow gvrow in PlantGridView.Rows)
            {
                watering(gvrow);
                break;
                
            }
        }

        protected void PlantGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}