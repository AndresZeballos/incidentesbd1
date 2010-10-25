using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.show
{
    public partial class ProjectStatics_Window : Form
    {
        private Project_Window project;
        private Cache cache;

        public ProjectStatics_Window(Project_Window project, Cache cache)
        {
            InitializeComponent();
            this.project = project;
            this.cache = cache;
            this.Location = this.project.Location;

            CargarValores();
        }

        private void CargarValores()
        {
            View_Logic view = new View_Logic();

            //nombre del proyecto
            this.textBox3.Text = this.cache.Proyecto.ProNom;
            
            //cantidad de incidentes del proyecto
            this.textBox5.Text = view.TotalProjectIncidents(this.cache.Proyecto.ProCod).ToString();
            
            //total de horas invertidas
            int cantHoras = 0;
            DataSet incidentes = new View_Logic().View_GeneralIncidentsStat(this.cache.Proyecto.ProCod);
            DataTable dtInc = incidentes.Tables["incidente"];
            foreach (DataRow drowInc in dtInc.Rows)
            {
                int incCod = drowInc.Field<int>("incCod");
                DataSet historia = view.HistoriaIncidente(incCod);
                DataTable dtHist = historia.Tables["historia"];
                foreach (DataRow drowHist in dtHist.Rows)
                {
                    cantHoras = cantHoras + drowHist.Field<int>("histHrs");
                }
            }
            this.textBox6.Text = cantHoras.ToString();

            //cargo grid con estados y cantidad de incidentes por estado
            DataTable estados = new DataTable();
            estados.Columns.Add("Estado", typeof(string));
            estados.Columns.Add("Cantidad Incidentes", typeof(int));

            IList<string> listaEstados = view.View_GeneralState();

            foreach (string estCod in listaEstados)
            {
                estados.Rows.Add(estCod, view.TotalStateIncidents(estCod));
            }
            this.dataGridView2.DataSource = estados;

            //cargo grid con estadisticas por incidente
            DataTable incTbl = new DataTable();
            incTbl.Columns.Add("Codigo", typeof(int));
            incTbl.Columns.Add("Resumen", typeof(string));
            incTbl.Columns.Add("% Avance", typeof(int));
            incTbl.Columns.Add("Desvio en dias", typeof(int));
            incTbl.Columns.Add("Desvio en horas", typeof(int));

            int incCodStat;
            string incResStat;
            int incPorcentajeStat;
            int incDesvDiasStat;
            int incDesHrsStat;

            //para cada incidente del proyecto calculo las estadisticas
            foreach (DataRow drowIncStat in dtInc.Rows)
            {
                incCodStat = drowIncStat.Field<int>("incCod");
                incResStat = drowIncStat.Field<string>("incRes");
                //si el tiempo estimado es 0, descarto las estadisticas para este incidente
                if (drowIncStat.Field<int>("incEstHrs") == 0)
                {
                    incPorcentajeStat = 0;
                    incDesHrsStat = 0;
                    incDesvDiasStat = 0;
                }
                else
                {
                    int cantHorasStat = 0;
                    DataSet historiaStat = view.HistoriaIncidente(incCodStat);
                    DataTable dtHistStat = historiaStat.Tables["historia"];
                    foreach (DataRow drowHistStat in dtHistStat.Rows)
                    {
                        cantHorasStat = cantHorasStat + drowHistStat.Field<int>("histHrs");
                    }

                    //evaluo si la fecha de fin se ha excedido de la fecha de fin estimada
                    if (drowIncStat.Field<DateTime>("incFecFin") >= drowIncStat.Field<DateTime>("incEstFecFin"))
                    {
                        TimeSpan days = drowIncStat.Field<DateTime>("incFecFin") - drowIncStat.Field<DateTime>("incEstFecFin");
                        incDesvDiasStat = (int)days.TotalDays;
                    }
                    else
                    {
                        incDesvDiasStat = 0;
                    }

                    // evaluo si la cantidad de horas estimada es mayor a la actualmente trabajada
                    incDesHrsStat = drowIncStat.Field<int>("incEstHrs");
                    if (incDesHrsStat > cantHorasStat)
                    {
                        //calculo el porcentaje de avance 
                        incPorcentajeStat = (cantHorasStat * 100) / incDesHrsStat;
                        //no hay desvio
                        incDesHrsStat = 0;
                    }
                    else
                    {
                        incDesHrsStat = cantHorasStat - incDesHrsStat;
                        incPorcentajeStat = 100;                        
                    }                    
                }
                incTbl.Rows.Add(incCodStat, incResStat, incPorcentajeStat, incDesvDiasStat, incDesHrsStat);
            }
            this.dataGridView1.DataSource = incTbl;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProjectStatics_Window_Load(object sender, EventArgs e)
        {

        }

        private void ProjectStatics_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.project.Location = this.Location;
            this.project.Visible = true;
        }
    }
}
