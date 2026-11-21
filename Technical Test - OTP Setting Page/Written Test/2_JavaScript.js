// 2.1 Simple JS & Logic question

var x = 2;
var y1 = x << 3;
var y2 = x + x + x + x + x + x + x + x;

console.log(y1);
console.log(y2);


// 2.2 Prototype in JS

String.prototype.repeat = function (count) {
    if (count < 0) {
        throw new RangeError('Repeat count must be non-negative');
    }

    var result = '';
    for (var i = 0; i < count; i++) {
        result += this;
    }
    return result;
};

console.log('hello'.repeat(3)); 
