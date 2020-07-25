/*
Declare uma variável `pessoa`, que receba suas informações pessoais.
As propriedades e tipos de valores para cada propriedade desse objeto devem ser:
- `nome` - String
- `sobrenome` - String
- `genero` - String
- `idade` - Number
- `altura` - Number
- `peso` - Number
- `andando` - Boolean - recebe "falso" por padrão
- `caminhouQuantosMetros` - Number - recebe "zero" por padrão
*/

var pessoa = {
    nome : 'Larissa',
    sobrenome : 'Carvalho',
    genero : 'Feminino',
    idade : 18,
    altura : 1.57,
    peso : 45,
    andando : false,
    caminhouQuantosMetros : 0
};

// Typeof

console.log( typeof pessoa.nome );      // string
console.log( typeof pessoa.sobrenome ); // string
console.log( typeof pessoa.genero );    // string
console.log( typeof pessoa.idade );     // number
console.log( typeof pessoa.altura );    // number
console.log( typeof pessoa.peso );      // number
console.log( typeof pessoa.andando );   // boolean
console.log( typeof pessoa.caminhouQuantosMetros );  // number      



/*
Adicione um método ao objeto `pessoa` chamado `fazerAniversario`. O método deve
alterar o valor da propriedade `idade` dessa pessoa, somando `1` a cada vez que
for chamado.
*/

//



/*
Adicione um método ao objeto `pessoa` chamado `andar`, que terá as seguintes
características:
- Esse método deve receber por parâmetro um valor que representará a quantidade
de metros caminhados;
- Ele deve alterar o valor da propriedade `caminhouQuantosMetros`, somando ao
valor dessa propriedade a quantidade passada por parâmetro;
- Ele deverá modificar o valor da propriedade `andando` para o valor
booleano que representa "verdadeiro";
*/

//



/*
Adicione um método ao objeto `pessoa` chamado `parar`, que irá modificar o valor
da propriedade `andando` para o valor booleano que representa "falso".
*/

//



/*
Crie um método chamado `nomeCompleto`, que retorne a frase:
- "Olá! Meu nome é [NOME] [SOBRENOME]!"
*/

//



/*
Crie um método chamado `mostrarIdade`, que retorne a frase:
- "Olá, eu tenho [IDADE] anos!"
*/

//



/*
Crie um método chamado `mostrarPeso`, que retorne a frase:
- "Eu peso [PESO]Kg."
*/

//



/*
Crie um método chamado `mostrarAltura` que retorne a frase:
- "Minha altura é [ALTURA]m."
*/

//



/*
Agora vamos trabalhar um pouco com o objeto criado:
Qual o nome completo da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/

function nomeCompleto() {
    return 'Olá! Meu nome é ' + pessoa.nome + ' ' + pessoa.sobrenome
};

console.log( nomeCompleto() );  // Olá! Meu nome é larissa Cravalho



/*
Qual a idade da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/

function mostrarIdade() {
    return 'Olá, eu tenho ' + pessoa.idade + ' anos!'
};

console.log( mostrarIdade() );  // "Olá, eu tenho 18 anos!"



/*
Qual o peso da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/

function mostrarPeso() {
    return 'Eu peso ' + pessoa.peso + 'Kg.'
};

console.log( mostrarPeso() );   // Eu peso 45Kg.



/*
Qual a altura da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/

function mostrarAltura() {
    return 'Minha altura é ' + pessoa.altura + 'm.'
};

console.log( mostrarAltura() );     // Minha altura é 1.57m.



/*
Faça a `pessoa` fazer 3 aniversários.
*/

pessoa.fazerAniversario = function() {
    pessoa.idade ++;
}

pessoa.fazerAniversario();
pessoa.fazerAniversario();
pessoa.fazerAniversario();



/*
Quantos anos a `pessoa` tem agora? (Use a instrução para responder e
comentários inline ao lado da instrução para mostrar qual foi a resposta
retornada)
*/

console.log( pessoa.idade );    // 21



/*
Agora, faça a `pessoa` caminhar alguns metros, invocando o método `andar` 3x,
com as distâncias diferentes passadas por parâmetro.
*/

pessoa.andar = function( qtdM ) {
    pessoa.caminhouQuantosMetros = pessoa.caminhouQuantosMetros + qtdM
};

pessoa.andar( 5 );
pessoa.andar( 9 );
pessoa.andar( 13 );
pessoa.andando = true;

console.log( pessoa.caminhouQuantosMetros );    // 27



/*
A pessoa ainda está andando? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/

pessoa.andando ? console.log( true ) : console.log( false );    // true



/*
Se a pessoa ainda está andando, faça-a parar.
*/

function parar() {
    return pessoa.andando = false;
}

console.log( parar() );    // false



/*
E agora: a pessoa ainda está andando? (Use uma instrução para responder e
comentários inline ao lado da instrução para mostrar a resposta retornada)
*/

pessoa.andando ? console.log( true ) : console.log( false );    // false



/*
Quantos metros a pessoa andou? (Use uma instrução para responder e comentários
inline ao lado da instrução para mostrar a resposta retornada)
*/

console.log( pessoa.caminhouQuantosMetros );    // 27


/*
Agora, vamos deixar a brincadeira um pouco mais divertida! :D
Crie um método para o objeto `pessoa` chamado `apresentacao`. Esse método deve
retornar a string:
- "Olá, eu sou o [NOME COMPLETO], tenho [IDADE] anos, [ALTURA], meu peso é [PESO] e, só hoje, eu já caminhei [CAMINHOU QUANTOS METROS] metros!"

Só que, antes de retornar a string, você vai fazer algumas validações:
- Se o `genero` de `pessoa` for "Feminino", a frase acima, no início da
apresentação, onde diz "eu sou o", deve mostrar "a" no lugar do "o";
- Se a idade for `1`, a frase acima, na parte que fala da idade, vai mostrar a
palavra "ano" ao invés de "anos", pois é singular;
- Se a quantidade de metros caminhados for igual a `1`, então a palavra que
deve conter no retorno da frase acima é "metro" no lugar de "metros".
- Para cada validação, você irá declarar uma variável localmente (dentro do
método), que será concatenada com a frase de retorno, mostrando a resposta
correta, de acordo com os dados inseridos no objeto.
*/

pessoa.apresentacao = function() {

    // feminino
    if (pessoa.genero === 'Feminino') {
        var fem = ' a ';
        return 'Olá, eu sou' + fem + pessoa.nome + ' ' + pessoa.sobrenome + ', tenho ' + pessoa.idade + ' anos, ' + pessoa.altura +
        'm, meu peso é ' + pessoa.peso + 'Kg e, só hoje, eu já caminhei ' + pessoa.caminhouQuantosMetros + ' metros!';
    } 
    else if (pessoa.idade === 1, pessoa.genero === 'Feminino') {
        var fem = ' a '
        var age = 'ano, ';
        return 'Olá, eu sou' + fem + pessoa.nome + ' ' + pessoa.sobrenome + ', tenho ' + pessoa.idade + age + pessoa.altura +
        'm, meu peso é ' + pessoa.peso + 'Kg e, só hoje, eu já caminhei ' + pessoa.caminhouQuantosMetros + ' metros!';
    } 
    else if (pessoa.caminhouQuantosMetros === 1) {
        var fem = ' a ';
        var m = 'metro!';
        return 'Olá, eu sou' + fem + pessoa.nome + ' ' + pessoa.sobrenome + ', tenho ' + pessoa.idade + ' anos, ' + pessoa.altura +
        'm, meu peso é ' + pessoa.peso + 'Kg e, só hoje, eu já caminhei ' + pessoa.caminhouQuantosMetros + m;
    }

    // masculino
    else if (pessoa.idade === 1) {
        var age = 'ano, ';
        return 'Olá, eu sou o ' + pessoa.nome + ' ' + pessoa.sobrenome + ', tenho ' + pessoa.idade + age + pessoa.altura +
        'm, meu peso é ' + pessoa.peso + 'Kg e, só hoje, eu já caminhei ' + pessoa.caminhouQuantosMetros + ' metros!';
    } 
    else if (pessoa.caminhouQuantosMetros === 1) {
        var m = 'metro!';
        return 'Olá, eu sou o ' + pessoa.nome + ' ' + pessoa.sobrenome + ', tenho ' + pessoa.idade + ' anos, ' + pessoa.altura +
        'm, meu peso é ' + pessoa.peso + 'Kg e, só hoje, eu já caminhei ' + pessoa.caminhouQuantosMetros + m;
    }
    else {
        return 'Olá, eu sou o ' + pessoa.nome + ' ' + pessoa.sobrenome + ', tenho ' + pessoa.idade + ' anos, ' + pessoa.altura +
        'm, meu peso é ' + pessoa.peso + 'Kg e, só hoje, eu já caminhei ' + pessoa.caminhouQuantosMetros + ' metros!';
    }
};

console.log( pessoa.apresentacao() );


/* Agora, apresente-se. */

//