$(document).ready(function () {
    $(".css tr").each(function () { $(this).find("td input:text").each(function () { $(this).addClass("TextColor"); }); });
});
function check_digit(e, obj, intsize, deczize) {

    var keycode;

    if (window.event) keycode = window.event.keyCode;
    else if (e) keycode = e.which;
    else return true;
    var fieldval = (obj.value);
    var dots = fieldval.split(".").length;

    if (deczize == 0) {
        if (keycode == 46) {return false;}
    }
    if (keycode == 46) {
        if (dots > 1) {

            return false;
        } else {

            return true;
        }
    }
    if (keycode == 8 || keycode == 9 || keycode == 46 || keycode == 13) // back space, tab, delete, enter 
    {
        return true;
    }
    if ((keycode >= 32 && keycode <= 45) || keycode == 47 || (keycode >= 58 && keycode <= 127)) {
        return false;
    }
    if (fieldval == "0" && keycode == 48)
        return false;

 
        if (fieldval.indexOf(".") != -1) {
            if (keycode == 46)
                return false;
            var splitfield = fieldval.split(".");
            if (splitfield[1].length >= deczize && keycode != 8 && keycode != 0)
                return false;
        }
        else if (fieldval.length >= intsize && keycode != 46) {
            return false;
        }
        else return true;
  



   
}
