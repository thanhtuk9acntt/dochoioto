using System;
using System.Text;

namespace AppCode.Entities 
{
	public class ECategories
	{
		public ECategories()
		{
		}
		
		public ECategories(int vId, string vCategoryName, string vDescription)
		{
			this.Id = vId;
			this.CategoryName = vCategoryName;
			this.Description = vDescription;
		}
		public int Id
		{ get;set; }
		public string CategoryName
		{ get;set; }
		public string Description
		{ get;set; }
	}
}