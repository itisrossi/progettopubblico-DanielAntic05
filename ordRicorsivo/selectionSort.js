let numeri = new Array(4);
let inizio = 0;
let fine = numeri.length -1;
// riempio l'array
for (let i=0; i<numeri.length; i++){
    numeri[i] = window.prompt("Inserisci un numero");
    
}


selectionSort(numeri, inizio, fine);

function selectionSort(numeri, inizio, fine){
    let posMinimo = 0;
if (inizio === fine){
    return;
} else{
    posMinimo = posizioneMinimo(numeri, inizio, fine);
    // alert(posMinimo);
    scambia(numeri, inizio, posMinimo);
    for (let i=0; i< numeri.length; i++){
        console.log(numeri[i]);
    }
    selectionSort(numeri, inizio+1, fine);
}
}



function posizioneMinimo(numeri, inizio, fine){
    // alert("inizio1 "+inizio);
if (inizio === fine)
    return inizio;
else{
    let posMinimoRestante = posizioneMinimo(numeri, inizio +1, fine); 
    // alert("inizio2 "+inizio);
    // alert(posMinimoRestante);
    if(numeri[inizio] < numeri[posMinimoRestante]){
        return inizio;
    }
    else
        return posMinimoRestante;
}
}

function scambia(numeri, inizio, posMinimo){
    let tmp = numeri[posMinimo];
    // alert(numeri[inizio]);
    numeri[posMinimo] = numeri[inizio];
    
    numeri[inizio] = tmp;
    // alert(numeri[inizio]);
    return;

}

selectionSort(numeri, 0, numeri.length -1);


function quickSort(numeri, inizio, fine){
    if (inizio === fine)
        return;

    else {
        let pivot = numeri[inizio];
        let posPivot = partition(numeri, inizio, fine);
        quickSort(numeri, inizio, posPivot -1);
        quickSort(numeri, posPivot +1, fine);
    }
}

for (let i=0; i< numeri.length; i++){
    console.log(numeri[i]);
}