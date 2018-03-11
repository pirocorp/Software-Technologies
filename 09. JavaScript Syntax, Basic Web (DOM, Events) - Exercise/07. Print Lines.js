function solve(lines) {
    for(let i = 0; i < lines.length; i++){
        let currentLine = lines[i];

        if(currentLine === 'Stop'){
            break
        }

        console.log(currentLine)
    }
}

solve(['Line 1', 'Line 2', 'Line 3', 'Stop', 'Test']);