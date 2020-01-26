const MAX_DEEPTH = 4;
const tab = document.getElementById("tab");

function create_tab() {
	var tab = document.getElementById("tab");
	tab.innerHTML = null;
	var row_len = 5;
	var col_len = Math.pow(2, row_len);
	var arr = Array(9,12,15,10,6,8,2,18,9,5,19,7,10,4,16); //初始化显示的表格数字，由题目给出的
	for(var i = 0; i < row_len; i++) {
		var tr = document.createElement("tr");
		for(var j = 0; j < col_len; j++) {
			var td = document.createElement("td");
			var set_in = document.createElement("input");
			set_in.setAttribute("id", "th");
			set_in.setAttribute("value", arr.shift());
			//设置table样式
			td.setAttribute("style", "height: 50px;padding: 0px;");
			td.appendChild(set_in);
			tr.appendChild(td);
			if(row_len - j == row_len - i) {
				break;
			}
		}
		tab.appendChild(tr);
		var collens = tab.getElementsByTagName("tr")[i].getElementsByTagName("td").length;
		for(var j = 0; j < collens; j++) {
			tab.getElementsByTagName("tr")[i].getElementsByTagName("td")[j].setAttribute("colspan", col_len / (i + 1));
		}
	}
}
//生成随机数填充表格
function randnum() {
	var tab = document.getElementById("tab");
	var row_len = tab.getElementsByTagName("tr").length;
	for(var i = 0; i < row_len; i++) {
		var ColLenofrow = tab.getElementsByTagName("tr")[i].getElementsByTagName("td").length;
		for(var j = 0; j < ColLenofrow; j++) {
			tab.getElementsByTagName("tr")[i].getElementsByTagName("td")[j].childNodes[0].setAttribute("value", Math.ceil(Math.random() * 100));
			tab.getElementsByTagName("tr")[i].getElementsByTagName("td")[j].childNodes[0].setAttribute("style", "margin: 0px;text-align: center;width: 100%;height: 100%;");
		}
	}
}
//重置,重新生成表格
function reset() {
	var tab = document.getElementById("tab");
	var row_len = tab.getElementsByTagName("tr").length;
	for(var i = 0; i < row_len; i++) {
		var ColLenofrow = tab.getElementsByTagName("tr")[i].getElementsByTagName("td").length;
		for(var j = 0; j < ColLenofrow; j++) {
			tab.getElementsByTagName("tr")[i].getElementsByTagName("td")[j].childNodes[0].setAttribute("style", "margin: 0px;text-align: center;width: 100%;height: 100%;");
		}
	}
}


/*最大总和*/
function getMaxValuePath(count_deep, count_loc, tab) {
	if (count_deep == MAX_DEEPTH){	//	通过深度来判断是否达到最后一层
		//	获取左和右的值
		const value = getNode(count_deep, count_loc).intValue;
		console.log("22:"+value);
		return {
			val: value,
			path: [getNode(count_deep, count_loc)]
		};
	} else {	//	不是最后一层，则处理下一层，对比下层返回的树进行处理
		//	获取当前数字块的数字
		const value = getNode(count_deep, count_loc).intValue;

		const leftPath = getMaxValuePath(count_deep+1, count_loc, tab);	// 获得左边的子树的值和路径
		const rightPath = getMaxValuePath(count_deep+1, count_loc+1, tab);	// 获得右边子树的值和路径

		if (leftPath.val > rightPath.val) {	// 判断下层返回值，返回大的值加本层的值，并记录路径
			leftPath.val = leftPath.val + value;	// 当前节点值加上左边子树的值
			leftPath.path.push(getNode(count_deep, count_loc));
			return leftPath;
		} else {
			rightPath.val = rightPath.val + value;
			rightPath.path.push(getNode(count_deep, count_loc));
			return rightPath;
		}
	}
}

//获取数字格内的值，并且转换成整形
function getNode(deep, loc) {
	const node = tab.getElementsByTagName("tr")[deep].getElementsByTagName("td")[loc].childNodes[0]
	node.intValue = parseInt(node.value)
	return node;
}

//得出结果
function Calculation(){
	reset();

	const loc = [];

	const count_deep = 0;
	const count_loc = 0;

	const val = getNode(count_deep, count_loc).value;
	const max_value_path = getMaxValuePath(count_deep,count_loc,tab);
	// const max_value = max_value_path.reduce((acc, node) => acc + node.intValue, 0)//通过路径获取值，并累加，得最大总和
	max_value_path.path.forEach(function(e){
		e.setAttribute("style","background-color: #FF69B4;margin: 0px;text-align: center;width: 100%;height: 100%;");
	});
	alert("最大总和为: " + max_value_path.val);
	console.log("最大总和为: " + max_value_path.val);
}
