using NetVips;
using System;
using System.IO;
using System.Web.UI;

namespace NetVipsCrash
{
    public partial class _Default : Page
    {
        protected void OnServerClick(object sender, EventArgs e)
        {
            var sourceImagePath = Server.MapPath("~/images/source.jpg");
            var targetImagePath = Server.MapPath("~/images/thumbnail.webp");
            using (var source = System.IO.File.OpenRead(sourceImagePath))
            {
                using (var thumbnail = NetVips.Image.ThumbnailStream(source, 
                           width: 500, 
                           height: 500,  
                           size: Enums.Size.Down, 
                           failOn: Enums.FailOn.Error))
                {
                    var options = new VOption
                    {
                        { "strip", true },
                        { "Q", 85 },
                    };
                    using (var output = File.Open(targetImagePath, FileMode.Create))
                    {
                        thumbnail.WriteToStream(output, ".webp", options);
                    }
                }
            }
            Response.Redirect(Request.Url.PathAndQuery);
        }
    }
}