using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeleniumTests

{
	public class OWA_UICreateGroup
	{
		//step 1: General Information
		public string fraMainCreatePage = "//*[@id='wizard']";
		public string tabStep1 = "//*[@id='yarnball']/ul/li[1]/a";
		public string fraMainStep1 = "//*[@id='step-1']";
		public string txtGroupName = "//*[@id='Name']";
		public string txtRemark = "//*[@id='Description']";
		public string btnPrevious = "//*[@id='wizard']/div[3]/a[3]";
		public string btnNext = "//*[@id='wizard']/div[3]/a[2]";
		public string btnFinish = "//*[@id='wizard']/div[3]/a[1]";
		public string msgRequiredField = "//div[@id='wizard']/div[3]/div[2]";
		
		//step 2: Select Licensees (expend from OWA_ManageGroup for using)
		public string tabStep2 = "//*[@id='yarnball']/ul/li[2]/a";
		public string fraMainStep2 = "//*[@id='step-2']";
		
		//step 3: Grant Permission (expend from OWA_ManageGroup for using)
		public string tabStep3 = "//*[@id='yarnball']/ul/li[3]/a";
		public string fraMainStep3 = "//*[@id='step-3']";
		
		//step 4: Summary 
		public string tabStep4 = "//*[@id='yarnball']/ul/li[4]/a";
		public string fraMainStep4 = "//*[@id='step-4']";
		public string lblGroupName = "//tr[2]/td[2]/span";
		public string lblRemark = "//tr[3]/td[2]/span";
		public string lnkEditGeneral = "//tbody/tr[1]/td/a";
		public string lnkEditLicensee = "//tbody/tr[5]/td/a";
		public string lnkEditPermission = "//thead/tr[1]/td/a";
		
	}
}
