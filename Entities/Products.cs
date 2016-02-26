
using System;
using System.Text;

namespace AppCode.Entities 
{
	public class EProducts
	{
		public EProducts()
		{
		}
		
		public EProducts(int vid, string vProductName, int vCategoryId, string vDescription, Decimal vOldPrice, Decimal vNewPrice, string vImageList)
		{
			this.id = vid;
			this.ProductName = vProductName;
			this.CategoryId = vCategoryId;
			this.Description = vDescription;
			this.OldPrice = vOldPrice;
			this.NewPrice = vNewPrice;
			this.ImageList = vImageList;
		}
		public int id
		{ get;set; }
		public string ProductName
		{ get;set; }
		public int CategoryId
		{ get;set; }
		public string Description
		{ get;set; }
		public Decimal OldPrice
		{ get;set; }
		public Decimal NewPrice
		{ get;set; }
		public string ImageList
		{ get;set; }
	}
}