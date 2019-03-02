using System;
using System.Text;
using Feature.Marketing.Model.Events;
using Sitecore.XConnect;

namespace TresDivas.Website.Classes.ExperienceProfile
{
    public class ProductInfoTabBuilder : TabBuilderBase
    {
        public override string TabLabel => "Products";
        public override string Heading => "Purchased Products";

        public override string RenderToString(Guid contactId)
        {

            Contact model = GetContact(contactId);

            var interactions = model.Interactions;

            var products = new StringBuilder();

            products.Append($"<div id=\"ProductRow\" class=\"row\">");
            products.Append($"<div id=\"LeftContactColumn\" class=\"col-md-4\">");
            products.Append(
                "<span style=\"padding-bottom:15px;color:#121212;font-weight:bold;font-size:1.167em;\" id=\"ProductsTitle\">Products</span>");

            if (interactions == null)
            {
                products.Append($"<div id=\"productsHandleBorder\">");
                products.Append($"<span id=\"productsHandleLabel\"><em>No products info available.</em></span></div>");
            }
            else
            {
                foreach (var interaction in interactions)
                {
                    foreach (var evt in interaction.Events)
                    {
                        if (evt.GetType() != typeof(ProductRegistrationGoal)) continue;

                        var tweetAboutProd = (ProductRegistrationGoal) evt;

                        if (tweetAboutProd.ProductRegistration == null) continue;

                        var prodInfo = tweetAboutProd.ProductRegistration;

                        if (prodInfo == null) continue;
                        products.Append($"<div id=\"productsHandleBorder\">");
                        products.Append($"<span id=\"productsHandleLabel\">Product Hashtag: &nbsp;</span>");
                        products.Append($"<span id=\"productsHandleValue\">{prodInfo.ProductHashtag}</span></div>");
                        products.Append($"<span id=\"productsHandleLabel\">Product Serial #: &nbsp;</span>");
                        products.Append($"<span id=\"productsHandleValue\">{prodInfo.SerialNumber}</span></div>");
                    }
                }
            }

            products.Append($"</div><div id=\"MiddleContactColumn\" class=\"col-md-4\"></div>");
            products.Append($"<div id=\"RightContactColumn\" class=\"col-md-4\"></div>");
            products.Append($"</div>");

            return products.ToString();
        }
    }
}

       