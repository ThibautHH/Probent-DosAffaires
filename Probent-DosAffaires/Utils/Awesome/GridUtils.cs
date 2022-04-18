using System.Collections.Generic;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Omu.AwesomeMvc;

namespace ProbentWeb.Utils.Awesome
{
	public static class GridUtils
	{
		private static string GetPopupName<T>(this IHtmlHelper<T> html, string action, string gridId) => action + html.Awe().GetContextPrefix() + gridId;

		public static string InlineCancelBtn<T>(this IHtmlHelper<T> html, string text = "Cancel") => html.Awe()
				.Button()
				.Text(text)
				.CssClass("btn-center o-glcanb awe-nonselect o-gl o-glbtn")
				.ToString();

		public static string InlineDeleteFormatForGrid<T>(this IHtmlHelper<T> html, string gridId, string key = "Id", bool noFocus = false, string cancel = "Cancel", string delete = "Delete")
		{
			string popupName = html.GetPopupName("delete", gridId);

			return DeleteFormat(popupName, delete, key, buttonClass: "o-glh", noFocus: noFocus) +
				InlineCancelBtn(html, cancel);
		}

		public static IHtmlContent InlineCreateButtonForGrid<T>(this IHtmlHelper<T> html, string gridId, object? parameters = null, string text = "Create")
		{
			gridId = html.Awe().GetContextPrefix() + gridId;
			string jsonParameters = JsonConvert.SerializeObject(parameters, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { StringEscapeHandling = StringEscapeHandling.EscapeHtml });

			return html.Awe().Button()
				.Text(text)
				.OnClick(string.Format("$('#{0}').data('api').inlineCreate({1})", gridId, jsonParameters));
		}

		public static IHtmlContent CreateButtonForGrid<T>(this IHtmlHelper<T> html, string gridId, object? parameters = null, string text = "Create") => html.Awe().Button()
				.Text(text)
				.OnClick(html.Awe().OpenPopup(html.GetPopupName("create", gridId)).Params(parameters));

		public static string EditFormatForGrid<T>(this IHtmlHelper<T> html, string gridId, string key = "Id", bool setId = false, bool nofocus = false, int? height = null)
		{
			string popupName = html.GetPopupName("edit", gridId);

			OpenPopup click = html.Awe().OpenPopup(popupName).Params(new { id = $".({key})" });
			if (height.HasValue)
			{
				click.Height(height.Value);
			}

			Button button = html.Awe().Button()
				.CssClass("awe-nonselect editbtn")
				.HtmlAttributes(new { aria_label = "edit" })
				.Text("<span class='ico-crud ico-edit'></span>")
				.OnClick(click);

			Dictionary<string, object> attrdict = new();

			if (setId)
			{
				attrdict.Add("id", $"gbtn{popupName}.{key}");
			}

			if (nofocus)
			{
				attrdict.Add("tabindex", "-1");
			}

			button.HtmlAttributes(attrdict);

			return button.ToString();
		}

		public static string DeleteFormatForGrid<T>(this IHtmlHelper<T> html, string gridId, string key = "Id", bool nofocus = false)
		{
			gridId = html.Awe().GetContextPrefix() + gridId;

			return DeleteFormatForGrid(gridId, key, nofocus);
		}

		public static string EditFormat(string popupName, string key = "Id", bool setId = false, bool nofocus = false)
		{
			string idattr = "";
			if (setId)
			{
				idattr = $"id = 'gbtn{popupName}.{key}'";
			}

			string tabindex = nofocus ? "tabindex = \"-1\"" : string.Empty;

			return string.Format("<button aria-label=\"edit\" type=\"button\" class=\"awe-btn awe-nonselect editbtn\" {3} {2}" +
								 " onclick=\"awe.open('{0}', {{ params:{{ id: '.({1})' }} }}, event)\"><span class='ico-crud ico-edit'></span></button>",
				popupName, key, idattr, tabindex);
		}

		public static string DeleteFormat(string popupName, string delete = "Delete", string key = "Id", string? deleteContent = null, string? buttonClass = null, bool noFocus = false)
		{
			if (deleteContent == null)
			{
				deleteContent = "<span class=\"btn-cont\">" + delete + "</span>";
			}

			string tabindex = noFocus ? "tabindex = \"-1\"" : string.Empty;

			return string.Format("<button aria-label=\"delete\" type=\"button\" class=\"btn-center awe-btn o-gledtb awe-nonselect o-glh o-glbtn delbtn {3}\"" +
				"{4} onclick=\"awe.open('{0}', {{ params:{{ id: '.({1})' }} }}, event)\">{2}</button>",
				popupName, key, deleteContent, buttonClass, tabindex);
		}

		public static string InlineEditFormat(string edit = "Edit", string save = "Save", bool nofocus = false)
		{
			string tabindex = nofocus ? "tabindex = \"-1\"" : string.Empty;
			return string.Format("<button type=\"button\" class=\"btn-center awe-btn o-gledtb awe-nonselect o-glh o-glbtn\" {0} ><span class=\"btn-cont\">{1}</span></button>" +
								 "<button type=\"button\" class=\"btn-center awe-btn o-glsvb awe-nonselect o-gl o-glbtn\"><span class=\"btn-cont\">{2}</span></button>", tabindex, edit, save);
		}

		public static string EditFormatForGrid(string gridId, string key = "Id", bool setId = false, bool nofocus = false) => EditFormat("edit" + gridId, key, setId, nofocus);

		public static string DeleteFormatForGrid(string gridId, string key = "Id", bool nofocus = false) => DeleteFormat("delete" + gridId, key: key, noFocus: nofocus);

		public static string EditGridNestFormat() => "<button type='button' class='awe-btn editnst'><span class='ico-crud ico-edit'></span></button>";

		public static string DeleteGridNestFormat() => "<button type='button' class='awe-btn delnst'><span class='ico-crud ico-del'></span></button>";

		public static string AddChildFormat() => "<button type='button' class='awe-btn awe-nonselect o-pad' onclick=\"awe.open('createNode', { params:{ parentId: '.(Id)' } })\">add child</button>";

		public static string MoveBtn() => "<button type=\"button\" class=\"awe-movebtn awe-btn\" tabindex=\"-1\"><i class=\"awe-icon\"></i></button>";
	}
}