using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NTPTest.StackExchange.Common;
using NTPTest.StackExchange.Entity;
using NTPTest.StackExchange.Repository;

namespace NTPTest
{
    public partial class Questions : System.Web.UI.Page
    {
        #region Private Methods

        private LoggingHandler _loggingHandler;


        private void ClearScreen()
        {
            txtPageId.Text = "1";
            txtPageSize.Text = "50";

            txtFromDate.Text = string.Empty;
            txtToDate.Text = string.Empty;

            lblOperationResult.Text = string.Empty;
            
            gvAllRecords.DataSource = null;
            gvAllRecords.DataBind();
        }

        private List<QuestionEntity> SelectAllByFactors()
        {
            try
            {
                using (var repository = new QuestionsRepository())
                {
                    repository.Order = OrderType.Descending;
                    repository.Sort = SortType.Creation;
                    //repository.FromDate =
                    //repository.ToDate =
                    //repository.Min = 
                    //repository.Max = 
                    repository.Page = 1;
                    repository.PageSize = 50;
                    return repository.SelectItemsFiltered();
                }
            }
            catch (Exception ex)
            {
                //Log exception error
                _loggingHandler.LogEntry(ExceptionHandler.GetExceptionMessageFormatted(ex), true);

                lblOperationResult.Text = "Sorry, loading All Questions operation failed." + Environment.NewLine + ex.Message;
            }

            return null;
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            _loggingHandler = new LoggingHandler();

            if (!IsPostBack)
            {
                ClearScreen();
            }
        }

        protected void btnClearScreen_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        protected void btnGetQuestions_Click(object sender, EventArgs e)
        {
            gvAllRecords.DataSource = SelectAllByFactors();
            gvAllRecords.DataBind();
        }

    }
}