function solve(inputLines) {
    let arr = [];

    for (let i = 0; i < inputLines.length; i++){
        let tokens = inputLines[i].split(' ');
        let command = tokens[0];
        let argument = Number(tokens[1]);

        if(command === 'add'){
            arr.push(argument)
        } else  if (command === 'remove'){
            if(argument > -1 && argument < arr.length){
                arr.splice(argument, 1);
            }
        }
    }

    console.log(arr.join("\n"));
}

solve(['add 3','add 5','remove 1','add 2']);