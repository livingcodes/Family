var log = txt => console.log(txt);

String.prototype.num = function (dft) {
  var n = Number(this);
  if (isNaN(n)) {
    if (!dft)
      dft = 0;
    return dft;
  } else
    return n;
}
var ꙩ = sel => document.querySelector(sel);
var ꙫ = sel => document.querySelectorAll(sel);

Element.prototype.ꙩ = function(sel) {
  return this.querySelector(sel);
}
Element.prototype.ꙫ = function(sel) {
  return this.querySelectorAll(sel);
}

Element.prototype.atr = function(name, val) {
  if (val)
    this.setAttribute(name, val);
  else
    return this.getAttribute(name);
}

Element.prototype.dat = function(name) {
  return this.getAttribute("data-"+name);
}

function post(url, obj) {
  return fetch(url, {
    method: "POST",
    headers: {"Content-Type": "application/json"},
    body: JSON.stringify(obj)
  })
}