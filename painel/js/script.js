var elementosDuvida = document.querySelectorAll('.duvida')

elementosDuvida.forEach(function (duvida)
{
    duvida.addEventListener('click', function ()
    {

        duvida.classList.toggle('ativa')
    })
})

var Botao = document.querySelector('.botao');

Botao.addEventListener('mouseover', function() 
{
    this.style.backgroundColor = "transparent";
    this.style.border = "2px solid #009989";
    this.style.color = "#009989";
});

Botao.addEventListener('mouseout', function() 
{
    this.style.backgroundColor = "#009989";
    this.style.border = "none";
    this.style.color = "#fff";
});

var BotaoTransparente = document.querySelector('.botao-transparente');

BotaoTransparente.addEventListener('mouseover', function() 
{
    this.style.backgroundColor = "#009989";
    this.style.border = "none";
    this.style.color = "#fff";
});

BotaoTransparente.addEventListener('mouseout', function()
{
    this.style.backgroundColor = "transparent";
    this.style.color = "#009989";
});

// var ItensNavbar = document.querySelectorAll('#inicio, #sobre, #como, #duvidas');

// ItensNavbar.addEventListener('mouseover', function()
// {
//     this.style.color = "#26313b";
// });

// ItensNavbar.addEventListener('mouseout', function()
// {
//     this.style.color = "#fff";
// });

// var Header = document.querySelector('.header');

// window.addEventListener('scroll', function() {
//     if (window.scrollY > 0) 
//     {
//         Header.classList.remove('.header'); // Verde quando está no topo
//         Header.classList.add('.header.scrolled'); // Verde quando está no topo
//     } else 
//     {

//         Header.style.backgroundColor = ".header"; // Vermelho quando está no topo
//     }
// });


