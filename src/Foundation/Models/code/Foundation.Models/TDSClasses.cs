






















#pragma warning disable 1591
#pragma warning disable 0108
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Team Development for Sitecore.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;   
using System.Collections.Generic;   
using System.Linq;
using System.Text;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Fields;
using Sitecore.Globalization;
using Sitecore.Data;
using Sitecore.Data.Items;
using SystemSpecialized = System.Collections.Specialized;



namespace Foundation.Models
{

    public partial interface IGlassBase{
        
        [SitecoreId]
        Guid Id{ get; }

        [SitecoreInfo(SitecoreInfoType.Name)]
        string ItemName { get; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        Language Language{ get; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        int Version { get; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        string Url { get; }

        [SitecoreInfo(SitecoreInfoType.Path)]
        string Path { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        string TemplateName { get; set; }

        [SitecoreItem]
        Item Item { get; }
    }

    public abstract partial class GlassBase : IGlassBase{
        
        [SitecoreId]
        public virtual Guid Id{ get; private set;}

        [SitecoreInfo(SitecoreInfoType.Name)]
        public string ItemName { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Language)]
        public virtual Language Language{ get; private set; }

        [SitecoreInfo(SitecoreInfoType.Version)]
        public virtual int Version { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Url)]
        public virtual string Url { get; private set; }

        [SitecoreInfo(SitecoreInfoType.Path)]
        public virtual string Path { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateId)]
        public Guid TemplateId { get; set; }

        [SitecoreInfo(SitecoreInfoType.TemplateName)]
        public string TemplateName { get; set; }

        [SitecoreItem]
        public virtual Item Item { get; private set; }
    }
}
namespace Foundation.Models
{


 	/// <summary>
	/// IProduct_Details Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Modules/Product Details</para>	
	/// <para>ID: 13cf5071-f642-4639-aec7-b45a29c939c4</para>	
	/// </summary>
	[SitecoreType(TemplateId=IProduct_DetailsConstants.TemplateIdString )] //, Cachable = true
	public partial interface IProduct_Details : IGlassBase 
	{
			
					/// <summary>
					/// The Bagel Function field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: b9c46a24-959a-41fd-a697-65c341a132f1</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_DetailsConstants.Bagel_FunctionFieldName)]
					string Bagel_Function  {get; set;}
			
			
					/// <summary>
					/// The Description field.
					/// <para></para>
					/// <para>Field Type: Multi-Line Text</para>		
					/// <para>Field ID: 0f663071-efe6-4c41-b09b-ff5137d7b379</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_DetailsConstants.DescriptionFieldName)]
					string Description  {get; set;}
			
			
					/// <summary>
					/// The Extra Lift field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: e7971b67-73c0-4bf3-a3fd-d2a85a226ef7</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_DetailsConstants.Extra_LiftFieldName)]
					string Extra_Lift  {get; set;}
			
			
					/// <summary>
					/// The Product Image field.
					/// <para></para>
					/// <para>Field Type: Image</para>		
					/// <para>Field ID: db0e3e15-dc51-4075-865a-0084c20c854d</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_DetailsConstants.Product_ImageFieldName)]
					Image Product_Image  {get; set;}
			
			
					/// <summary>
					/// The Product Name field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 8a69926f-388a-4296-83a6-454c1fb2359d</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_DetailsConstants.Product_NameFieldName)]
					string Product_Name  {get; set;}
			
			
					/// <summary>
					/// The Shade Selection field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 5972527d-0e03-4f55-9bc4-9b707896a1c2</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_DetailsConstants.Shade_SelectionFieldName)]
					string Shade_Selection  {get; set;}
			
			
	}


	public static partial class IProduct_DetailsConstants{

			public const string TemplateIdString = "13cf5071-f642-4639-aec7-b45a29c939c4";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Product Details";

		
			
			public static readonly ID Bagel_FunctionFieldId = new ID("b9c46a24-959a-41fd-a697-65c341a132f1");
			public const string Bagel_FunctionFieldName = "Bagel Function";
			
		
			
			public static readonly ID DescriptionFieldId = new ID("0f663071-efe6-4c41-b09b-ff5137d7b379");
			public const string DescriptionFieldName = "Description";
			
		
			
			public static readonly ID Extra_LiftFieldId = new ID("e7971b67-73c0-4bf3-a3fd-d2a85a226ef7");
			public const string Extra_LiftFieldName = "Extra Lift";
			
		
			
			public static readonly ID Product_ImageFieldId = new ID("db0e3e15-dc51-4075-865a-0084c20c854d");
			public const string Product_ImageFieldName = "Product Image";
			
		
			
			public static readonly ID Product_NameFieldId = new ID("8a69926f-388a-4296-83a6-454c1fb2359d");
			public const string Product_NameFieldName = "Product Name";
			
		
			
			public static readonly ID Shade_SelectionFieldId = new ID("5972527d-0e03-4f55-9bc4-9b707896a1c2");
			public const string Shade_SelectionFieldName = "Shade Selection";
			
			

	}

	
	/// <summary>
	/// Product_Details
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Modules/Product Details</para>	
	/// <para>ID: 13cf5071-f642-4639-aec7-b45a29c939c4</para>	
	/// </summary>
	[SitecoreType(TemplateId=IProduct_DetailsConstants.TemplateIdString)] //, Cachable = true
	public partial class Product_Details  : GlassBase, IProduct_Details
	{
	   
		
				/// <summary>
				/// The Bagel Function field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: b9c46a24-959a-41fd-a697-65c341a132f1</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_DetailsConstants.Bagel_FunctionFieldName)]
				public virtual string Bagel_Function  {get; set;}
					
		
				/// <summary>
				/// The Description field.
				/// <para></para>
				/// <para>Field Type: Multi-Line Text</para>		
				/// <para>Field ID: 0f663071-efe6-4c41-b09b-ff5137d7b379</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_DetailsConstants.DescriptionFieldName)]
				public virtual string Description  {get; set;}
					
		
				/// <summary>
				/// The Extra Lift field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: e7971b67-73c0-4bf3-a3fd-d2a85a226ef7</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_DetailsConstants.Extra_LiftFieldName)]
				public virtual string Extra_Lift  {get; set;}
					
		
				/// <summary>
				/// The Product Image field.
				/// <para></para>
				/// <para>Field Type: Image</para>		
				/// <para>Field ID: db0e3e15-dc51-4075-865a-0084c20c854d</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_DetailsConstants.Product_ImageFieldName)]
				public virtual Image Product_Image  {get; set;}
					
		
				/// <summary>
				/// The Product Name field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 8a69926f-388a-4296-83a6-454c1fb2359d</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_DetailsConstants.Product_NameFieldName)]
				public virtual string Product_Name  {get; set;}
					
		
				/// <summary>
				/// The Shade Selection field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 5972527d-0e03-4f55-9bc4-9b707896a1c2</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_DetailsConstants.Shade_SelectionFieldName)]
				public virtual string Shade_Selection  {get; set;}
					
			
	}

}
namespace Foundation.Models
{


 	/// <summary>
	/// ISite Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Foundation/Helix/Site</para>	
	/// <para>ID: 6669dc16-f106-44b5-96be-7a31ae82b5b5</para>	
	/// </summary>
	[SitecoreType(TemplateId=ISiteConstants.TemplateIdString )] //, Cachable = true
	public partial interface ISite : IGlassBase 
	{
			
	}


	public static partial class ISiteConstants{

			public const string TemplateIdString = "6669dc16-f106-44b5-96be-7a31ae82b5b5";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Site";

			

	}

	
	/// <summary>
	/// Site
	/// <para></para>
	/// <para>Path: /sitecore/templates/Foundation/Helix/Site</para>	
	/// <para>ID: 6669dc16-f106-44b5-96be-7a31ae82b5b5</para>	
	/// </summary>
	[SitecoreType(TemplateId=ISiteConstants.TemplateIdString)] //, Cachable = true
	public partial class Site  : GlassBase, ISite
	{
	   
			
	}

}
namespace Foundation.Models
{


 	/// <summary>
	/// IProduct_Reviews Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Modules/Product Reviews</para>	
	/// <para>ID: c8ce317d-43c1-489f-9471-a318c0e824d4</para>	
	/// </summary>
	[SitecoreType(TemplateId=IProduct_ReviewsConstants.TemplateIdString )] //, Cachable = true
	public partial interface IProduct_Reviews : IGlassBase 
	{
			
					/// <summary>
					/// The Review Description field.
					/// <para></para>
					/// <para>Field Type: Multi-Line Text</para>		
					/// <para>Field ID: 8c33e703-fdf9-4b4f-9817-3305ff863d91</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_ReviewsConstants.Review_DescriptionFieldName)]
					string Review_Description  {get; set;}
			
			
					/// <summary>
					/// The Reviews Title field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 9f4ed8ac-ec41-48d1-b20e-cba327fce98c</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IProduct_ReviewsConstants.Reviews_TitleFieldName)]
					string Reviews_Title  {get; set;}
			
			
	}


	public static partial class IProduct_ReviewsConstants{

			public const string TemplateIdString = "c8ce317d-43c1-489f-9471-a318c0e824d4";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Product Reviews";

		
			
			public static readonly ID Review_DescriptionFieldId = new ID("8c33e703-fdf9-4b4f-9817-3305ff863d91");
			public const string Review_DescriptionFieldName = "Review Description";
			
		
			
			public static readonly ID Reviews_TitleFieldId = new ID("9f4ed8ac-ec41-48d1-b20e-cba327fce98c");
			public const string Reviews_TitleFieldName = "Reviews Title";
			
			

	}

	
	/// <summary>
	/// Product_Reviews
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Modules/Product Reviews</para>	
	/// <para>ID: c8ce317d-43c1-489f-9471-a318c0e824d4</para>	
	/// </summary>
	[SitecoreType(TemplateId=IProduct_ReviewsConstants.TemplateIdString)] //, Cachable = true
	public partial class Product_Reviews  : GlassBase, IProduct_Reviews
	{
	   
		
				/// <summary>
				/// The Review Description field.
				/// <para></para>
				/// <para>Field Type: Multi-Line Text</para>		
				/// <para>Field ID: 8c33e703-fdf9-4b4f-9817-3305ff863d91</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_ReviewsConstants.Review_DescriptionFieldName)]
				public virtual string Review_Description  {get; set;}
					
		
				/// <summary>
				/// The Reviews Title field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 9f4ed8ac-ec41-48d1-b20e-cba327fce98c</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IProduct_ReviewsConstants.Reviews_TitleFieldName)]
				public virtual string Reviews_Title  {get; set;}
					
			
	}

}
namespace Foundation.Models
{


 	/// <summary>
	/// IReview Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Content/Review</para>	
	/// <para>ID: d1643d84-f19b-428f-82db-12c361288351</para>	
	/// </summary>
	[SitecoreType(TemplateId=IReviewConstants.TemplateIdString )] //, Cachable = true
	public partial interface IReview : IGlassBase 
	{
			
					/// <summary>
					/// The Review Text field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: e5a224f3-347f-4756-92d4-de254ccb1383</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IReviewConstants.Review_TextFieldName)]
					string Review_Text  {get; set;}
			
			
					/// <summary>
					/// The Sentiment field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 6f8b7882-a3ea-409c-97cc-4abf2dec2226</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IReviewConstants.SentimentFieldName)]
					string Sentiment  {get; set;}
			
			
					/// <summary>
					/// The Twitter Description field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 32e18c18-e507-46c2-8959-52b89bb1eb82</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IReviewConstants.Twitter_DescriptionFieldName)]
					string Twitter_Description  {get; set;}
			
			
					/// <summary>
					/// The Twitter Handle field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 162a8603-e5a5-4810-92a0-f68dfd0c46e9</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IReviewConstants.Twitter_HandleFieldName)]
					string Twitter_Handle  {get; set;}
			
			
					/// <summary>
					/// The Twitter Image field.
					/// <para></para>
					/// <para>Field Type: Image</para>		
					/// <para>Field ID: c58c6ada-9ad6-4ec2-9406-b5957ad0e6b8</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(IReviewConstants.Twitter_ImageFieldName)]
					Image Twitter_Image  {get; set;}
			
			
	}


	public static partial class IReviewConstants{

			public const string TemplateIdString = "d1643d84-f19b-428f-82db-12c361288351";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Review";

		
			
			public static readonly ID Review_TextFieldId = new ID("e5a224f3-347f-4756-92d4-de254ccb1383");
			public const string Review_TextFieldName = "Review Text";
			
		
			
			public static readonly ID SentimentFieldId = new ID("6f8b7882-a3ea-409c-97cc-4abf2dec2226");
			public const string SentimentFieldName = "Sentiment";
			
		
			
			public static readonly ID Twitter_DescriptionFieldId = new ID("32e18c18-e507-46c2-8959-52b89bb1eb82");
			public const string Twitter_DescriptionFieldName = "Twitter Description";
			
		
			
			public static readonly ID Twitter_HandleFieldId = new ID("162a8603-e5a5-4810-92a0-f68dfd0c46e9");
			public const string Twitter_HandleFieldName = "Twitter Handle";
			
		
			
			public static readonly ID Twitter_ImageFieldId = new ID("c58c6ada-9ad6-4ec2-9406-b5957ad0e6b8");
			public const string Twitter_ImageFieldName = "Twitter Image";
			
			

	}

	
	/// <summary>
	/// Review
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Content/Review</para>	
	/// <para>ID: d1643d84-f19b-428f-82db-12c361288351</para>	
	/// </summary>
	[SitecoreType(TemplateId=IReviewConstants.TemplateIdString)] //, Cachable = true
	public partial class Review  : GlassBase, IReview
	{
	   
		
				/// <summary>
				/// The Review Text field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: e5a224f3-347f-4756-92d4-de254ccb1383</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IReviewConstants.Review_TextFieldName)]
				public virtual string Review_Text  {get; set;}
					
		
				/// <summary>
				/// The Sentiment field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 6f8b7882-a3ea-409c-97cc-4abf2dec2226</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IReviewConstants.SentimentFieldName)]
				public virtual string Sentiment  {get; set;}
					
		
				/// <summary>
				/// The Twitter Description field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 32e18c18-e507-46c2-8959-52b89bb1eb82</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IReviewConstants.Twitter_DescriptionFieldName)]
				public virtual string Twitter_Description  {get; set;}
					
		
				/// <summary>
				/// The Twitter Handle field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 162a8603-e5a5-4810-92a0-f68dfd0c46e9</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IReviewConstants.Twitter_HandleFieldName)]
				public virtual string Twitter_Handle  {get; set;}
					
		
				/// <summary>
				/// The Twitter Image field.
				/// <para></para>
				/// <para>Field Type: Image</para>		
				/// <para>Field ID: c58c6ada-9ad6-4ec2-9406-b5957ad0e6b8</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(IReviewConstants.Twitter_ImageFieldName)]
				public virtual Image Twitter_Image  {get; set;}
					
			
	}

}
namespace Foundation.Models
{


 	/// <summary>
	/// IProduct_Detail Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Pages/Product Detail</para>	
	/// <para>ID: dd18839a-0567-484a-ae3b-0407e6c4c336</para>	
	/// </summary>
	[SitecoreType(TemplateId=IProduct_DetailConstants.TemplateIdString )] //, Cachable = true
	public partial interface IProduct_Detail : IGlassBase 
	{
			
	}


	public static partial class IProduct_DetailConstants{

			public const string TemplateIdString = "dd18839a-0567-484a-ae3b-0407e6c4c336";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Product Detail";

			

	}

	
	/// <summary>
	/// Product_Detail
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Pages/Product Detail</para>	
	/// <para>ID: dd18839a-0567-484a-ae3b-0407e6c4c336</para>	
	/// </summary>
	[SitecoreType(TemplateId=IProduct_DetailConstants.TemplateIdString)] //, Cachable = true
	public partial class Product_Detail  : GlassBase, IProduct_Detail
	{
	   
			
	}

}
namespace Foundation.Models
{


 	/// <summary>
	/// ITwitter_UT_Filters Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Feature/Tres Divas/Marketing/Twitter UT Filters</para>	
	/// <para>ID: e0fa547f-f051-4c50-987d-083f43c8543a</para>	
	/// </summary>
	[SitecoreType(TemplateId=ITwitter_UT_FiltersConstants.TemplateIdString )] //, Cachable = true
	public partial interface ITwitter_UT_Filters : IGlassBase 
	{
			
					/// <summary>
					/// The Channel field.
					/// <para></para>
					/// <para>Field Type: Droptree</para>		
					/// <para>Field ID: 5b913a2a-0c3f-4892-b98e-05702124bc03</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.ChannelFieldName)]
					Guid Channel  {get; set;}
			
			
					/// <summary>
					/// The Filter Out Retweets field.
					/// <para></para>
					/// <para>Field Type: Checkbox</para>		
					/// <para>Field ID: 86c1108a-d3a3-4fe9-ac1d-c9c4cc394c14</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.Filter_Out_RetweetsFieldName)]
					bool Filter_Out_Retweets  {get; set;}
			
			
					/// <summary>
					/// The Goal Or Outcome field.
					/// <para></para>
					/// <para>Field Type: Droptree</para>		
					/// <para>Field ID: 0cbff226-2922-423c-85b3-baa946350044</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.Goal_Or_OutcomeFieldName)]
					Guid Goal_Or_Outcome  {get; set;}
			
			
					/// <summary>
					/// The Minimum Followers field.
					/// <para>What is the minimum number of followers a Twitter Account must have?</para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: c95e2975-a9f3-46de-a1ab-8d25f330a9af</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.Minimum_FollowersFieldName)]
					string Minimum_Followers  {get; set;}
			
			
					/// <summary>
					/// The Product Hashtag field.
					/// <para>(include #)</para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: be20ecdd-c11e-4335-9f32-f6e846ffebef</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.Product_HashtagFieldName)]
					string Product_Hashtag  {get; set;}
			
			
					/// <summary>
					/// The Product Name field.
					/// <para></para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 15e8f258-7b1f-4ed9-9269-971e76c6726a</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.Product_NameFieldName)]
					string Product_Name  {get; set;}
			
			
					/// <summary>
					/// The Twitter Account Age field.
					/// <para>What is the minimum age of the Twitter Account?  (in months)</para>
					/// <para>Field Type: Single-Line Text</para>		
					/// <para>Field ID: 4225cd64-0541-402e-a711-8f52613ef35f</para>
					/// <para>Custom Data: </para>
					/// </summary>
					[SitecoreField(ITwitter_UT_FiltersConstants.Twitter_Account_AgeFieldName)]
					string Twitter_Account_Age  {get; set;}
			
			
	}


	public static partial class ITwitter_UT_FiltersConstants{

			public const string TemplateIdString = "e0fa547f-f051-4c50-987d-083f43c8543a";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Twitter UT Filters";

		
			
			public static readonly ID ChannelFieldId = new ID("5b913a2a-0c3f-4892-b98e-05702124bc03");
			public const string ChannelFieldName = "Channel";
			
		
			
			public static readonly ID Filter_Out_RetweetsFieldId = new ID("86c1108a-d3a3-4fe9-ac1d-c9c4cc394c14");
			public const string Filter_Out_RetweetsFieldName = "Filter Out Retweets";
			
		
			
			public static readonly ID Goal_Or_OutcomeFieldId = new ID("0cbff226-2922-423c-85b3-baa946350044");
			public const string Goal_Or_OutcomeFieldName = "Goal Or Outcome";
			
		
			
			public static readonly ID Minimum_FollowersFieldId = new ID("c95e2975-a9f3-46de-a1ab-8d25f330a9af");
			public const string Minimum_FollowersFieldName = "Minimum Followers";
			
		
			
			public static readonly ID Product_HashtagFieldId = new ID("be20ecdd-c11e-4335-9f32-f6e846ffebef");
			public const string Product_HashtagFieldName = "Product Hashtag";
			
		
			
			public static readonly ID Product_NameFieldId = new ID("15e8f258-7b1f-4ed9-9269-971e76c6726a");
			public const string Product_NameFieldName = "Product Name";
			
		
			
			public static readonly ID Twitter_Account_AgeFieldId = new ID("4225cd64-0541-402e-a711-8f52613ef35f");
			public const string Twitter_Account_AgeFieldName = "Twitter Account Age";
			
			

	}

	
	/// <summary>
	/// Twitter_UT_Filters
	/// <para></para>
	/// <para>Path: /sitecore/templates/Feature/Tres Divas/Marketing/Twitter UT Filters</para>	
	/// <para>ID: e0fa547f-f051-4c50-987d-083f43c8543a</para>	
	/// </summary>
	[SitecoreType(TemplateId=ITwitter_UT_FiltersConstants.TemplateIdString)] //, Cachable = true
	public partial class Twitter_UT_Filters  : GlassBase, ITwitter_UT_Filters
	{
	   
		
				/// <summary>
				/// The Channel field.
				/// <para></para>
				/// <para>Field Type: Droptree</para>		
				/// <para>Field ID: 5b913a2a-0c3f-4892-b98e-05702124bc03</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.ChannelFieldName)]
				public virtual Guid Channel  {get; set;}
					
		
				/// <summary>
				/// The Filter Out Retweets field.
				/// <para></para>
				/// <para>Field Type: Checkbox</para>		
				/// <para>Field ID: 86c1108a-d3a3-4fe9-ac1d-c9c4cc394c14</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.Filter_Out_RetweetsFieldName)]
				public virtual bool Filter_Out_Retweets  {get; set;}
					
		
				/// <summary>
				/// The Goal Or Outcome field.
				/// <para></para>
				/// <para>Field Type: Droptree</para>		
				/// <para>Field ID: 0cbff226-2922-423c-85b3-baa946350044</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.Goal_Or_OutcomeFieldName)]
				public virtual Guid Goal_Or_Outcome  {get; set;}
					
		
				/// <summary>
				/// The Minimum Followers field.
				/// <para>What is the minimum number of followers a Twitter Account must have?</para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: c95e2975-a9f3-46de-a1ab-8d25f330a9af</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.Minimum_FollowersFieldName)]
				public virtual string Minimum_Followers  {get; set;}
					
		
				/// <summary>
				/// The Product Hashtag field.
				/// <para>(include #)</para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: be20ecdd-c11e-4335-9f32-f6e846ffebef</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.Product_HashtagFieldName)]
				public virtual string Product_Hashtag  {get; set;}
					
		
				/// <summary>
				/// The Product Name field.
				/// <para></para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 15e8f258-7b1f-4ed9-9269-971e76c6726a</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.Product_NameFieldName)]
				public virtual string Product_Name  {get; set;}
					
		
				/// <summary>
				/// The Twitter Account Age field.
				/// <para>What is the minimum age of the Twitter Account?  (in months)</para>
				/// <para>Field Type: Single-Line Text</para>		
				/// <para>Field ID: 4225cd64-0541-402e-a711-8f52613ef35f</para>
				/// <para>Custom Data: </para>
				/// </summary>
				[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Team Development for Sitecore - GlassItem.tt", "1.0")]
				[SitecoreField(ITwitter_UT_FiltersConstants.Twitter_Account_AgeFieldName)]
				public virtual string Twitter_Account_Age  {get; set;}
					
			
	}

}
namespace Foundation.Models
{


 	/// <summary>
	/// IHome Interface
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Pages/Home</para>	
	/// <para>ID: e90f7bd6-1ebc-4356-ad1c-8f5a4b6c6440</para>	
	/// </summary>
	[SitecoreType(TemplateId=IHomeConstants.TemplateIdString )] //, Cachable = true
	public partial interface IHome : IGlassBase 
	{
			
	}


	public static partial class IHomeConstants{

			public const string TemplateIdString = "e90f7bd6-1ebc-4356-ad1c-8f5a4b6c6440";
			public static readonly ID TemplateId = new ID(TemplateIdString);
			public const string TemplateName = "Home";

			

	}

	
	/// <summary>
	/// Home
	/// <para></para>
	/// <para>Path: /sitecore/templates/Project/TresDivas/Pages/Home</para>	
	/// <para>ID: e90f7bd6-1ebc-4356-ad1c-8f5a4b6c6440</para>	
	/// </summary>
	[SitecoreType(TemplateId=IHomeConstants.TemplateIdString)] //, Cachable = true
	public partial class Home  : GlassBase, IHome
	{
	   
			
	}

}
