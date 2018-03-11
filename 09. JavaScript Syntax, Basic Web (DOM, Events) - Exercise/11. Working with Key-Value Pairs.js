function solve(inputLines) {
    let array = [];

    for (let i = 0; i < inputLines.length - 1; i++){
        let tokens = inputLines[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];
        array[key] = value;
    }

    let key = inputLines[inputLines.length - 1];

    if(key in array){
        console.log(array[key]);
    } else {
        console.log('None')
    }
}

solve(['3 bla','3 alb', '2']);