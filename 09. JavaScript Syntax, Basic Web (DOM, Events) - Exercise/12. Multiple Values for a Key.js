function solve(inputLines) {
    let arr = [];
    for (let i = 0; i < inputLines.length - 1; i++) {
        let tokens = inputLines[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];

        if (key in arr) {
            arr[key].push(value);
        } else {
            arr[key] = [];
            arr[key].push(value);
        }
    }

    let key = inputLines[inputLines.length - 1];

    if(key in arr){
        console.log(arr[key].join("\n"));
    } else {
        console.log('None');
    }
}

solve(['key value','key eulav','test tset','3']);