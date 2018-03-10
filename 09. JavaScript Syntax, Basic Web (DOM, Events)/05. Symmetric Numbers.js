function symetricNumbers(arr) {
    let limit = Number(arr[0]);
    let res = '';

    for (let i = 1; i <= limit; i++){
        if(isSymmetric(i.toString())){
            res += `${i} `;
        }
    }

    console.log(res);

    function isSymmetric (str) {
        let limit = str.length;

        for(let i = 0; i < limit / 2; i++){
            if(str[i] != str[limit - 1 - i]){
                return false;
            }
        }

        return true;
    }
}

symetricNumbers(['750'])