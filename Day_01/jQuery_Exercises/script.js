var pS = $("p");
console.log(pS);

pS.click(function () {
  pS.css("color", "red");
});

var inp = $("#abc");
inp.click(function () {
  inp.attr("value", "blue");
  inp.attr("type", "password");
});
