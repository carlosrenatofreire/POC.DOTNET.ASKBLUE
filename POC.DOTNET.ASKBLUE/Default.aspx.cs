using POC.DOTNET.ASKBLUE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace POC.DOTNET.ASKBLUE
{
    public partial class _Default : Page
    {

        #region Script para SQL

        //        USE[AskBlue]
        //GO

        ///* Criar um table type. */
        //CREATE TYPE CandidateTableType
        //   AS TABLE
        //      (Id INT,
        //        Nome VARCHAR(50)
        //      , Atividade INT
        //      , Nivel INT);
        //GO

        ///* Criar procedure para receber parametro type-table-valued */
        //CREATE PROCEDURE dbo.usp_InsertCandidatesByTableType
        //   @Candidates CandidateTableType READONLY
        //      AS
        //      SET NOCOUNT ON
        //      INSERT INTO Candidatos (Id, Nome, Atividade, Nivel)
        //      SELECT * FROM @Candidates;
        //        GO

        //        /* Criar tabela */
        //        CREATE TABLE[dbo].[Candidatos]
        //        (

        //            [Id][int] NOT NULL,

        //            [Nome] [varchar] (256) NULL,
        //	[Atividade][int] NULL,
        //	[Nivel][int] NULL
        //) ON[PRIMARY]
        //GO

        #endregion

        #region Events methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = GetCandidatesByDataTable();
                GridView1.DataBind();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            DataTable candidateDataTable = new DataTable();
            string connectionString = "Server=DESKTOP-LS3R4QN\\EXPRESS2022;Database=AskBlue;User Id=carlos.freire;Password=Password.123;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True"; // Substitua pelo seu connection string
            string sp_Candidate = "usp_InsertCandidatesByTableType";

            try
            {
                candidateDataTable = GetCandidatesByDataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(sp_Candidate, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter candidateParam = new SqlParameter("@Candidates", SqlDbType.Structured);
                    candidateParam.Value = candidateDataTable;
                    command.Parameters.Add(candidateParam);

                    command.ExecuteNonQuery();

                    lblMensagem.Text = "Os Candidatos foram salvos com sucesso!";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Erro: " + ex.Message.ToString();
            }

        }

        #endregion

        #region Private Methods

        private DataTable GetCandidatesByDataTable()
        {
            // Simulando uma fonte de dados (pode ser substituída por sua fonte de dados real)
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Nome", typeof(string));
            dt.Columns.Add("Profissional", typeof(int));
            dt.Columns.Add("Nível", typeof(int));

            // Preenchendo alguns dados de exemplo
            dt.Rows.Add(1, "João", AskBlueServices.BusinessAnalyst, AskBlueServiceLevel.InternShip);
            dt.Rows.Add(2, "Maria", AskBlueServices.Developer, AskBlueServiceLevel.Junior);
            dt.Rows.Add(3, "Pedro", AskBlueServices.TechLead, AskBlueServiceLevel.Middle);
            dt.Rows.Add(4, "Ana", AskBlueServices.QualityAnalyst, AskBlueServiceLevel.Senior);
            dt.Rows.Add(5, "David", AskBlueServices.SoftwareArchitect, AskBlueServiceLevel.Senior);

            return dt;
        }

        #endregion

    }
}