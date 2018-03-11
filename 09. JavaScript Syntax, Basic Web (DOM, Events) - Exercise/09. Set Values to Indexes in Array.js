function solve(inputLines) {
    let n = Number(inputLines[0]);
    let arr = new Array(n);

    for(let i = 0; i < n; i++){
        arr[i] = 0;
    }

    for (let i = 1; i < inputLines.length; i++){
        let tokens = inputLines[i]
            .split(' - ')
            .map(x => x.trim())
            .map(Number);
        let index = tokens[0];
        let value = tokens[1];
        arr[index] = value;
    }

    console.log(arr.join('\n'))
}

solve(['5', '0 - 3', '3 - -1', '4 - 2']);