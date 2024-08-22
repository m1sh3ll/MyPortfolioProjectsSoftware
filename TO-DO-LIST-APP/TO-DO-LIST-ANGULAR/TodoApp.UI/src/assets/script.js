const button = document.querySelector("button");
const output = document.querySelector(".output");

button.addEventListener("click", function(){
  const cost = document.querySelector("input");

  output.innerHTML = `
  <h1>Results</h1>
  Tip Rate  5%: $${(cost.value * 0.05).toFixed(2)}<br>
  Tip Rate 10%: $${(cost.value * 0.10).toFixed(2)}<br>
  Tip Rate 15%: $${(cost.value * 0.15).toFixed(2)}<br>
  Tip Rate 20%: $${(cost.value * 0.20).toFixed(2)}<br>
  Tip Rate 25%: $${(cost.value * 0.25).toFixed(2)}`
});
