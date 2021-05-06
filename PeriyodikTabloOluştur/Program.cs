using Newtonsoft.Json;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace PeriyodikTabloOluştur
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    class MyClass
    {
        [JsonProperty(PropertyName = "xpos")]
        public int xpos { get; set; }
        [JsonProperty(PropertyName = "ypos")]
        public int ypos { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "symbol")]
        public string symbol { get; set; }
        [JsonProperty(PropertyName = "number")]
        public string number { get; set; }
        [JsonProperty(PropertyName = "summary")]
        public string summary { get; set; }
    }
    class deneme
    {

        public int xeksenisayisi { get; set; }
        public int yekseninisayisi { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {

            var json = JsonConvert.DeserializeObject<List<MyClass>>(System.IO.File.ReadAllText(@"C:\Users\mustafa\Desktop\periyodik tablo\json2.txt"));
            var kb = JsonConvert.SerializeObject(json);
            var html = "<!DOCTYPE html><html lang=\"en\"><head>    <meta charset=\"UTF-8\">    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">    <title>PeryodikTablo</title>    <link rel=\"stylesheet\" href=\"./index.css\"></head><body>";
            html += @" <style> .grid {
  display: grid;
  grid-template-columns: auto auto auto auto auto auto auto auto auto auto auto auto auto auto auto auto auto auto;
}

.tarih {
  min-height: 37px;
  min-width: 42px;
  position: relative;
} 
a {
    text-decoration:none;
    color:blue;
    
}
</style>";

            html += "<div id=\"oyun1\">        <button type=\"radio\">Renk Yerleştirme</button>        <select name=\"renk\" id=\"\">            <option value=\"Kırmızı\">Kırmızı</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>            <option value=\"Siyah\">Siyah</option>        </select>    </div>    <div class=\"oyun2\">        <button type=\"radio\">Sembolik Adı,Adı,Atom Numarası</button>    </div>    <main>        <table style=\"margin: auto auto;border: 3px solid rgba(33, 77, 158, 0.472);border-collapse: collapse;  \">        <tbody>  ";

            var yatay = 1;
            var tr = 1;

            //List<deneme> deneme = new List<deneme>();
            //for (int i = 0; i < 9; i++)
            //{
            //    for (int k = 0; k < 18; k++)
            //    {
            //        deneme.Add(new PeriyodikTabloOluştur.deneme()
            //        {
            //            xeksenisayisi = k,
            //            yekseninisayisi = i
            //        });
                 
            //    }
            //}
            //for (int i = 0; i < deneme.Count; i++)
            //{
            //    if (yatay == 1)
            //    {
            //        html += "<tr>";
            //    }
            //    html += "<th style=\"border: 2px solid red;\">";
            //    html += " <div class=\"tarih\" style=\"min-height: 58px; min-width: 44px; position: relative; \">";
            //    html += "<span style=\"color: red; font-size: 10px; position: absolute; top: 0; left: 0; \">";
            //    if (deneme.Where(i=> i.))
            //    {

            //    }
            //}

            for (int i = 0; i < 180; i++)
            {
                if (yatay == 1)
                {
                    html += "<tr>";
                }

                html += "<th style=\"border: 2px solid red;\">";
                html += " <div class=\"tarih\" style=\"min-height: 58px; min-width: 44px; position: relative; \">";
                html += "<span style=\"color: red; font-size: 10px; position: absolute; top: 0; left: 0; \">";
                MyClass? sorgu = json.Where(i => i.xpos == yatay && i.ypos == tr).Select(i => new MyClass()
                {
                    name = i.name,
                    symbol = i.symbol,
                    number = i.number,
                    xpos = i.xpos,
                    ypos = i.ypos,
                    summary = i.summary
                }).FirstOrDefault();
                if (sorgu != null)
                {
                    html += sorgu.number;
                }
                html += "</span>";
                html += "<a ";
                if (sorgu != null)
                {
                    html += "href=\"https://en.wikipedia.org/wiki/" + sorgu.name +"\" target='_blank'"+ " title=\"" + sorgu.summary + "\"";
                }
                html +="style=\"display: block; text-align: center; font-size: 26px; \">";
                if (sorgu != null)
                {
                    html += sorgu.symbol;
                }
                html += "</a>";
                html += "<span style=\" display: block; font-size:13px; \">";
                if (sorgu != null)
                {
                    html += sorgu.name;
                }
                else
                {
                    html += "<p class=\"görünmesin\"></p>";
                }
                yatay++;
                html += "</span>";


                html += " </div>";

                if (yatay == 19)
                {
                    html += "</tr>";
                    tr++;
                    yatay = 1;
                }
            }

            //buradan sonrası yorum satırı olucak
            //foreach (var js in json)
            //    {


            //        if (yatay == 1)
            //        {
            //            html += "<tr>";
            //        }
            //        html += "<th style=\"border: 2px solid red;\">";
            //        html += " <div class=\"tarih\" style=\"min-height: 58px; min-width: 44px; position: relative; \">";
            //        html += "<span style=\"color: red; font-size: 10px; position: absolute; top: 0; left: 0; \">";

            //        if (js.xpos == yatay)
            //        {
            //            html += js.number;
            //        }
            //        html += "</span>";

            //        html += "<span style=\"display: block; text-align: center; font-size: 26px; \">";
            //        if (js.xpos == yatay)
            //        {
            //            html += js.name;
            //        }
            //        html += "</span>";
            //        html += "<span style=\" display: block; font-size:13px; \">";
            //        if (js.xpos == yatay)
            //        {
            //            html += js.name;
            //        }
            //        yatay++;
            //        html += "</span>";


            //        html += " </div>";
            //        if (yatay == 18)
            //        {
            //            html += "</tr>";
            //            tr++;
            //            yatay = 1;
            //        }
            //}
            //buradan önceisi yorum satırı olucak
            html += "<script>for (const iterator of document.getElementsByClassName(\"görünmesin\")) {";
            html += "iterator.parentElement.parentElement.parentElement.style.visibility = \"hidden\";}</script>";

            html += "</tbody>    </table>    </main></body></html>";
        }
    }
}