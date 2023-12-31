var log = txt => console.log(txt);

String.prototype.num = function(dft) {
  var n = Number(this);
  if (isNaN(n)) {
    if (!dft)
      dft = 0;
    return dft;
  } else
    return n;
}
String.prototype.rem = function(str) {
  return this.replace(str, "");
}
var ꙩ = sel => document.querySelector(sel);
var ꙫ = sel => document.querySelectorAll(sel);

Element.prototype.on = function (evNam, fn) {
  return this.addEventListener(evNam, fn);
}

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

Array.prototype.ea = function(itm, i, fn) {
  this.forEach(itm, i, fn);
}
NodeList.prototype.ea = function (itm, i, fn) {
  this.forEach(itm, i, fn);
}

function post(url, obj) {
  return fetch(url, {
    method: "POST",
    headers: {"Content-Type": "application/json"},
    body: JSON.stringify(obj)
  })
}