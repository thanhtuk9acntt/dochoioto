
using System;
using System.Text;
namespace AppCode.Entities 
{
	public class EServices
	{
		public EServices()  
		{
		}
		
		public EServices(int vid, string vServiceName, string vDescription, string vImageList)
		{
			this.id = vid;
			this.ServiceName = vServiceName;
			this.Description = vDescription;
			this.ImageList = vImageList;
		}
		public int id
		{ get;set; }
		public string ServiceName
		{ get;set; }
		public string Description
		{ get;set; }
		public string ImageList
		{ get;set; }
	}
}