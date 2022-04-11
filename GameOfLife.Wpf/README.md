## Conway's Game of Life

![Glider](Animated_glider_emblem.gif)

<sub>Creator: <span style="color:blue">Quuxplusone</span></sub>\
<sub>Quelle: <span style="color:blue">Wikimedia Commons</span></sub>


Das Spiel "Game of Life" wurde vom Mathematiker **John Horton Conway** entworfen und basiert auf einer Matrix, die man auch als einen zweidimensionalen zellulären Automaten kennt.

## Regeln:

Jede Zelle in der Matrix kann genau zwei Zustände annehmen: 
- lebendig
- tot 

Jede Zelle hat immer genau 8 Nachbarn und verändert sich mit ihren Folgengenerationen wie folgt:

<sub>Regeln von Conway</sub>

- Eine tote Zelle mit genau drei lebenden Nachbarn wird in der Folgegeneration nei geboren.\
    ![rule1](../Data/Matrix_rule1.png)

- Lebende Zellen mit weniger als zwei lebenden Nachbarn sterben in der Folgegeneration an Einsamkeit.\
    ![rule2](../Data/Matrix_rule2.png)

- Eine lebende Zelle mit zeri oder drei lebenden Nachbarn bleibt in der Folgegeneration am Leben.\
    ![rule3](../Data/Matrix_rule3.png)

- Lebende Zellen mit mehr als drei lebenden Nachbarn sterben in der Folgegeneration an Überbevölkerung.\
    ![rule4](../Data/Matrix_rule4.png)