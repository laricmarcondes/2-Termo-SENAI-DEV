console.log( 'teste' );     // teste

// Tipos de Dados

var idade = 18;
var nome = 'Larissa';
var sextaFeira = true;
var pessoa = {
    nome,
    idade,
    sobrenome : 'Carvalho'
};

var pessoas = [ pessoa, pessoa2 = {
    nome : 'Renata',
    idade : 37,
    desempregada : false
} ];

var naoDefinido = undefined;
var nulo = null;

// Diferenças entre undefined e null

var exemplo;
console.log( exemplo )      //undefined

var exemplo = null;
console.log( exemplo )      //null

// Typeof

console.log( typeof idade );        //number
console.log( typeof nome );         //string
console.log( typeof sextaFeira );   //boolen
console.log( typeof pessoa );       //object
console.log( typeof pessoa2 );      //object
console.log( typeof pessoas );      //object
console.log( typeof naoDefinido );  //undefined
console.log( typeof nulo );         //object
// nulo = object?? Nãooo, isto está errado, deveria retornar null, é um erro na construção da linguagem
// portanto, é recomendado utilizar o typof apenas em dados primitivos (number, string e boolean)

// Operadores Lógicos e Condicionais

// && (AND)

if ( idade > 18 && idade < 60){
    console.log( 'Ainda não pode se aposentar' )
};
// Ainda não pode se aposentar.

// || (OR)

var dia = 'sexta-feira';

// ==    comparam apenas o valor
// === comparam o valor e o tipo do dado

if ( dia === 'sexta-feira' || dia === 'quinta-feira' ) {
    console.log( 'Dia útil.' )
};
// Dia útil

// ! (NOT)

if (pessoa2.desempregada !== true) {
    console.log( 'Apessoa está empregada.' )
}
else {
    console.log( 'Apessoa está desempregada.' )
};
// A pessoa está empregada

// Ternário

1 > 2 ? console.log( 'Sim, 1 é maior que 2.' ) : console.log( 'Não, 1 não é maior que 2.' );
// Não. 1 não é maior que 2.

// Outra forma do exemplo anterior, com ternário

pessoa.desempregada ? console.log( 'A pessoa está desempregada.' ) : console.log( 'Apessoa está empregada.' );
// A pessoa está empregada.

// Funções

var nome = 'Larissa';
var sobrenome = 'Carvalho';

// Declaração de uma função

function nomeCompleto() {
    var anoNascimeto = '2001';
    return 'Meu nome completo é ' + nome + ' ' + sobrenome
};

    // Invocação de uma função
    
console.log( nomeCompleto() );
// Meu nome completo é Larissa Carvalho

// Parâmetros de uma funçao

function soma( x, y ) {
    return x + y
};

console.log( soma( 1, 2 ) );      // 3

// Métodos 

pessoa.altura = 1.57;

pessoa.crescer = function( qtdM ) {
    pessoa.altura = pessoa.altura + qtdM
};

console.log( 'Antes de crescer: '+ pessoa.altura );
// Antes de crescer: 1.57

pessoa.crescer ( 0.03 );
// .crescer() é um método do objeto pessoa

console.log( 'Depois de crescer: ' + pessoa.altura );
//Depois de crescer: 1.60