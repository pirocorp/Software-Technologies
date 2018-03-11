function solve(inputLines) {
    let object = {};

    for(let i = 0; i < inputLines.length; i++){
        let tokens = inputLines[i].split('->').map(x => x.trim());
        let key = tokens[0];
        let value = tokens[1];
        if(!isNaN(value)){
            value = Number(value);
        }
        object[key] = value;
    }

    console.log(JSON.stringify(object));
}

solve(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia']);