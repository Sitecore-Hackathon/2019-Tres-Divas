using System;
using System.Text;
using Feature.Marketing.Model.Facets;
using Sitecore.XConnect;

namespace TresDivas.Website.Classes.ExperienceProfile
{
    public class SocialTabBuilder : TabBuilderBase
    {
        public override string TabLabel => "Social";
        public override string Heading => "Social";
        public override string RenderToString(Guid contactId)
        {
            Contact model = GetContact(contactId);

            var twitter = new StringBuilder();

            TwitterAccountInfo t = null;

            if (model.Facets.ContainsKey("TwitterAccountInfo"))
            {
                t = (TwitterAccountInfo)model.Facets["TwitterAccountInfo"];
            }

            twitter.Append("<div id=\"SocialRow\" class=\"row\">");
            twitter.Append("<div id=\"LeftContactColumn\" class=\"col-md-4\">");
            twitter.Append(
                "<span style=\"padding-bottom:15px;color:#121212;font-weight:bold;font-size:1.167em;\" id=\"SocialTitle\">Twitter</span>");

            if (t == null)
            {
                twitter.Append("<div id=\"TwitterHandleBorder\">");
                twitter.Append("<span id=\"TwitterHandleLabel\"><em>No Twitter account info available.</em></span></div>");
            }
            else
            {
                twitter.Append("<div id=\"TwitterHandleBorder\">");
                twitter.Append("<span id=\"TwitterHandleLabel\">Twitter Handle: &nbsp;</span>");
                twitter.Append($"<span id=\"TwitterHandleValue\">{t.TwitterHandle}</span></div>");
                twitter.Append("<div id=\"NumFollowersBorder\">");
                twitter.Append("<span id=\"NumFollowersLabel\">Number of Followers: &nbsp;</span>");
                twitter.Append($"<span id=\"NumFollowersValue\">{t.NumberOfFollowers}</span></div>");
                twitter.Append("<div id=\"AcctAgeBorder\">");
                twitter.Append("<span id=\"AcctAgeLabel\">Account Age: &nbsp;</span>");
                twitter.Append($"<span id=\"AcctAgeValue\">{t.TwitterStartDate.ToShortDateString()}</span></div>");
                twitter.Append("<div id=\"VerifiedBorder\">");
                twitter.Append("<span id=\"VerifiedLabel\">Verified: &nbsp;</span>");
                twitter.Append($"<span id=\"VerifiedValue\">{t.VerifiedTwitterHandle}</span></div>");
            }
            twitter.Append("</div><div id=\"MiddleContactColumn\" class=\"col-md-4\"></div>");
            twitter.Append("<div id=\"RightContactColumn\" class=\"col-md-4\"></div>");
            twitter.Append("</div>");

            return twitter.ToString();
        }
    }
}