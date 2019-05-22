document.write('mon message');
document.write('<h1>les balises</h1>');

//les boites de dialogue
alert('hello');
confirm('');//boite avec bouton ok oi anuller
prompt('hello');//boite avec champs a remplir

var age = prompt('enter your age');
if (age < 18)
    document.write('vous etes mineur');
else 
    document.write('vous repondu avoir' + age + ' ans');
var i = 0;
while (i <= 3) {
    document.write(i === 3 ? i : i + '---');
    i++;
    
}
