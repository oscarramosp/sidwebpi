//a
function GetValue(y, z, l, r) {
    box = document.getElementById(y);
    x = '';
    if (l == '#') {
        x = ' ' + "UP_GETVARIABLE{'" + box.options[box.selectedIndex].value + "'}" + ' ';
    } else {
        x = ' ' + l + box.options[box.selectedIndex].text + r + ' ';
    }
    textedit = document.getElementById(z);
    if (textedit.createTextRange && textedit.caretPos) {
        var caretPos = textedit.caretPos;
        caretPos.text =
		caretPos.text.charAt(caretPos.text.length - 1) == ' ' ?
		x + ' ' : x;
    }
    else {
        textedit.value = textedit.value + x;
    }
}