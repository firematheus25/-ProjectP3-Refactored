#### Disciplina: Projeto de Software
#### Aluno: Wilamis Micael de Araujo Aviz
#### Professor: Baldoino Fonseca dos Santos Neto.
#### Projeto em Java com OO para a disciplina de Projeto de Software no semestre 2020.1

# Sistema de Folha de pagamentos
O objetivo do projeto é construir um sistema de folha de pagamento. O sistema consiste de um banco de dados de empregados de uma empresa além dos seus dados associados tais como cartões de ponto. O sistema deve pagar cada empregado. Empregados devem receber o salário correto, no momento correto, usando o método que eles preferem. Além do mais, várias taxas e impostos são deduzidos do seu salário.

* Alguns empregados são horistas. Eles recebem um salário por hora trabalhada. Eles submetem "cartões de ponto" todo dia para informar o número de horas trabalhadas naquele dia. Se um empregado trabalhar mais do que 8 horas, deve receber 1.5 a taxa normal durante as horas extras. Eles são pagos toda sexta-feira.

*  Alguns empregados recebem um salário fixo mensal. São pagos no último dia útil do mês (desconsidere feriados). Tais empregados são chamados "assalariados". 

* Alguns empregados assalariados são comissionados e portanto recebem uma comissão, um percentual das vendas que realizam. Eles submetem resultados de vendas que informam a data e valor da venda. O percentual de comissão varia de empregado para empregado. Eles são pagos a cada 2 sextas-feiras; neste momento, devem receber o equivalente de 2 semanas de salário fixo mais as comissões do período.

  * Empregados podem escolher o método de pagamento;
  * Podem receber um cheque pelos correios;
  * Podem receber um cheque em mãos;
  * Podem pedir depósito em conta bancária.
 
* Alguns empregados pertencem ao sindicato (para simplificar, só há um possível sindicato). O sindicato cobra uma taxa mensal do empregado e essa taxa pode variar entre empregados. A taxa sindical é deduzida do salário. Além do mais, o sindicato pode ocasionalmente cobrar taxas de serviços adicionais a um empregado. Tais taxas de serviço são submetidas pelo sindicato mensalmente e devem ser deduzidas do próximo contracheque do empregado. A identificação do empregado no sindicato não é a mesma da identificação no sistema de folha de pagamento.

* A folha de pagamento é rodada todo dia e deve pagar os empregados cujos salários vencem naquele dia. O sistema receberá a data até a qual o pagamento deve ser feito e calculará o pagamento para cada empregado desde a última vez em que este foi pago.

| Func. |  Título da funcionalidade                  |   Breve Descrição  |
| ----- | ---------------------------                |  ----------------- |
|   1   |     Adição de um empregado                 | Um novo empregado é adicionado ao sistema. Os seguintes atributos são fornecidos: nome, endereço, tipo (hourly, salaried, commissioned) e os atributos associados (salário horário, salário mensal, comissão). Um número de empregado (único) deve ser escolhido automaticamente pelo sistema. |
|   2   |     Remoção de um empregado                | Um empregado é removido do sistema. |
|   3   |     Lançar um Cartão de Ponto              | O sistema anotará a informação do cartão de ponto e a associará ao empregado correto. |
|   4   |     Lançar um Resultado Venda              | O sistema anotará a informação do resultado da venda e a associará ao empregado correto.|
|   5   |     Lançar uma taxa de serviço             | O sistema anotará a informação da taxa de serviço e a associará ao empregado correto. |
|   6   |     Alterar detalhes de um empregado       | Os seguintes atributos de um empregado podem ser alterados: nome, endereço, tipo (hourly,salaried,commisioned), método de pagamento, se pertence ao sindicato ou não, identificação no sindicato, taxa sindical |
|   7   |     Rodar a folha de pagamento para hoje   | O sistema deve achar todos os empregados que devem ser pagos no dia indicado, deve calcular o valor do salário e deve providenciar o pagamento de acordo com o método escolhido pelo empregado. |
|   8   |               Undo/redo                    | Qualquer transação associada as funcionalidades 1 a 7 deve ser desfeita (undo) ou refeita (redo). |
|   9   |            Agenda de Pagamento             | Cada empregado é pago de acordo com uma "agenda de pagamento". Empregados podem selecionar a agenda de pagamento que desejam. Por default, as agendas "semanalmente", "mensalmente" e "bi- semanalmente" são usadas, como explicado na descricao geral. Posteriormente, um empregado pode pedir para ser pago de acordo com qualquer uma dessas agendas.|
|  10   |Criação de Novas <br>Agendas de Pagamento   | A direção da empresa pode criar uma nova agenda de pagamento e disponibilizá-la para os empregados escolherem, se assim desejarem. Uma agenda é especificada através de um string. Alguns exemplos mostram as possibilidades: "mensal 1": dia 1 de todo mês "mensal 7": dia 7 de todo mês "mensal $": último dia útil de todo mês "semanal 1 segunda": toda semana às segundas-feiras "semanal 1 sexta": toda semana às sextas-feiras "semanal 2 segunda": a cada 2 semanas às segundas-feiras |


# Code Smell
* Duplicated Code
* Long Parameter List
* Long Method
* Large Class
* Shotgun Surgery
* Indecent Exposure

# Refatoramento

### Command
Foi utilizado o padrão de projeto Command para evitar de usar if/else ou switch/case nos menus do programa. Todos os menus estão no padrão Command. Foi criada uma interface de menu para executar o comando de acordo com o menu vigente. As mudanças estão no commit [59475bc](https://github.com/WilamisAviz15/PayrollRefactoring/commit/59475bc63956216cab9712ebe1575ed7c41ff7d1)

### Introduce Parameter Object
Em todas as funções eram passadas as pilhas de UNDO e REDO. Foi criado um objeto que contia ambas as pilhas evitando parametros desnecessários. Alteração pode ser vista no commit: [b5e5a09](https://github.com/WilamisAviz15/PayrollRefactoring/commit/b5e5a0986767729fe53756865af72b7bc743a384)

### Move Accumulation to Collecting Parameter
Na Classe Employee.java havia uma verificação dentro do toString() para saber se o empregado pertencia ao sindicato ou não, onde havia uma concatenação de string de acordo com a resposta obtida do if. Foi criado o método infoSyndicateConcat() e adicionado ao toString. A alteração está no commit [ce0395c](https://github.com/WilamisAviz15/PayrollRefactoring/commit/ce0395c92e0bbfccf13b4a0d1495cb9e83f54f60)

### Removing Generative Speculation
Foram removidos construtores, métodos e imports não utilizados em todo o code. As remoções estão aqui: 
[b8695c6](https://github.com/WilamisAviz15/PayrollRefactoring/commit/b8695c60fed6ace15b6f905799df04e04261be42)
