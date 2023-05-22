/*
for getting perrmission about ikandi and boutique pages like home etc;
BY US
*/
function uri(event1) 
{
    var url = window.location.protocol + "//" + window.location.host;
    var ikandi = new Array("http://www.ikandi.org.uk", "http://www.ikandi.org.uk:81", "http://stiplggns010:3220", "http://ikandi.org.uk:81", "http://ikandi.org.uk");
    var bipl = new Array("http://www.boutique.in", "http://www.boutique.in:81", "http://stiplggns010:3221");
    if (window.location.port == 3221 || url == bipl[0] || url == bipl[1] || url == bipl[2]) 
    {
        var corP = document.getElementById(event1.id).title;
        var urlnew = window.location.protocol + "//" + window.location.host + "/bipl" + corP; ;
        self.location = urlnew;
    }
    else if (window.location.port == 3220 || url == ikandi[0] || url == ikandi[1] || url == ikandi[2] || url == ikandi[3] || url == ikandi[4])
     {
        var corP = document.getElementById(event1.id).title;
        var urlnew;
        urlnew = window.location.protocol + "//" + window.location.host + "/ikand" + corP;
        self.location = urlnew;
    }
}