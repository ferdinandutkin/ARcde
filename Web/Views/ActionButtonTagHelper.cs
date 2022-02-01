using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace Web.Views
{

    public enum HttpVerbs { Get, Put, Post, Delete }

    [HtmlTargetElement("button", Attributes = "asp-action")]
    public class ActionButtonHelper : TagHelper
    {
        private readonly IUrlHelperFactory _helperFactory;


        [HtmlAttributeName("asp-method")]
        public HttpVerbs Method
        {
            get;
            set;
        }


        [HtmlAttributeName("asp-controller")]
        public string? Controller
        {
            get;
            set;
        }

        [HtmlAttributeName("asp-action")]
        public string? Action
        {
            get;
            set;
        }

        [HtmlAttributeName(DictionaryAttributePrefix = "asp-route-")]
        public Dictionary<string, object> RouteValues { get; set; } = new();


        [ViewContext]
        public ViewContext ViewContext
        {
            get;
            set;
        }


        public ActionButtonHelper(IUrlHelperFactory helperFactory)
        {
            _helperFactory = helperFactory;
        }

        private static readonly string _globalScriptContent = @"  
        window.actionButtonClickHandler ??= function (url, method) {
            fetch(url, {method})
                .then(response => {
                    console.log(response.status);
                    window.location.reload();
                });
        }
        document.currentScript.parentNode.removeChild(document.currentScript);
        ";



        private void InjectGlobalScript(TagHelperOutput output)
        {
            output.PreElement
                .AppendHtml("<script>")
                .AppendHtml(_globalScriptContent)
                .AppendHtml("</script>");
        }

        private void InjectLocalScript(TagHelperOutput output)
        {
            var urlHelper = _helperFactory.GetUrlHelper(ViewContext);

            output.PostElement
                .AppendHtml("<script>")
                .AppendHtml($@"document.currentScript.previousSibling.addEventListener('click', actionButtonClickHandler.bind(null, '{urlHelper.Action(new UrlActionContext() { Action = Action, Controller = Controller, Values = RouteValues })}', '{Method.ToString().ToUpper()}'));
                               document.currentScript.parentNode.removeChild(document.currentScript);")
                .AppendHtml("</script>");

        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            InjectGlobalScript(output);

            Controller ??= ViewContext.RouteData.Values["Conroller"].ToString();

            Action ??= ViewContext.RouteData.Values["Action"].ToString();

            InjectLocalScript(output);

         
        }



    }
}
