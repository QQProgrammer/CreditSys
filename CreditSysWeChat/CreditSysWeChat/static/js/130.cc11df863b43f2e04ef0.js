webpackJsonp([130],{1141:function(t,i,e){var c=e(1142);"string"==typeof c&&(c=[[t.i,c,""]]),c.locals&&(t.exports=c.locals);e(227)("643d3c20",c,!0)},1142:function(t,i,e){i=t.exports=e(226)(),i.push([t.i,"\n.read_top[data-v-634c7a48]{width: 100%;height:50px;background: #fff;line-height: 50px;display: -webkit-box;display: -webkit-flex;display: flex;\n}\n.read_top div[data-v-634c7a48]{width: 30%;text-align: center;font-size: 13px;color: #3E3E3E;\n}\n.read_top div[data-v-634c7a48]:nth-child(1){margin-left: 20%;\n}\n.read_top img[data-v-634c7a48]{width: 9px;\n}\n.topImg[data-v-634c7a48]{position: relative;top:-6px;left: 4px;\n}\n.botImg[data-v-634c7a48]{position: relative;top:2px;left: -5px;\n}\n.shoplist[data-v-634c7a48]{width:100%;margin-top: 6px;background: #fcfcfc;display: -webkit-box;display: -webkit-flex;display: flex;-webkit-flex-wrap:wrap;flex-wrap:wrap;\n}\n.shoplist .shop_box[data-v-634c7a48]{width: 44%;background: #fff;margin-bottom: 10px;margin-left: 4%;\n}\n.shopImgDiv[data-v-634c7a48]{width: 100%;text-align: center;\n}\n.shopImgDiv img[data-v-634c7a48]{width: 100%;\n}\n.shop_box p[data-v-634c7a48]{font-size: 12px;color: #3E3E3E;margin-top: 5px;\n}\n.shop_box .money[data-v-634c7a48]{margin-bottom: 5px;\n}\n.shop_box .money span[data-v-634c7a48]{color: #e00404; margin-right: 3px;\n}\n.shop_box .money img[data-v-634c7a48]{width:15px;position: relative;top: 3px;\n}\n.carIcon[data-v-634c7a48]{width: 50px;height: 50px;position: absolute;bottom: 50px;right: 20px;\n}\n.carIcon img[data-v-634c7a48]{width: 100%;height: 100%;\n}\n",""])},1143:function(t,i,e){var c=e(1144);"string"==typeof c&&(c=[[t.i,c,""]]),c.locals&&(t.exports=c.locals);e(227)("6afc698c",c,!0)},1144:function(t,i,e){i=t.exports=e(226)(),i.push([t.i,"\n#vux_view_box_body{background: #fcfcfc;\n}\n.readlist .vux-badge{position: relative;top: -65px;left: 35px;\n}\n",""])},1145:function(t,i,e){"use strict";(function(t){var c=e(64),a=e.n(c),n=e(41),s=e(63),o=1,r=0;i.a={components:{cookie:a.a,Badge:n.a},data:function(){return{carnumFlag:!1,carnum:0,img1:"",img2:"",img3:"",img4:"",categoryId:"",productList:[],count:"",hotelProvinceId:""}},methods:{getMemberById:function(){var t=this,i={MemberId:this.userId};this.$http({method:"POST",url:s.a.getMemberById,data:i}).then(function(i){var e=JSON.parse(i.data);if(0!=e.length){var c=e[0];t.hotelProvinceId=c.ProvinceId,t.getProductList(1,0),t.img1="../../static/credit/topr.png"}})},getProductList:function(t,i){var e=this,c={productType:0,categoryId:this.categoryId,productName:"",PageSize:999,IndexPage:1,priceOD:t,saleOD:i};this.$http({method:"post",url:s.a.getProductList,data:c}).then(function(t){e.productList=[];var i=JSON.parse(t.data);e.count=i.Count;for(var c=i.data,a=[],n=0;n<c.length;n++){var s=c[n];if("0"!=s.SaleProvince)if(-1==s.SaleProvince.indexOf("|"))s.SaleProvince=parseInt(s.SaleProvince),s.SaleProvince==e.hotelProvinceId&&a.push(s);else for(var o=s.SaleProvince.split("|"),r=0;r<o.length;r++){var p=o[r];p=parseInt(p),p==e.hotelProvinceId&&a.push(s)}else"0"==s.SaleProvince&&a.push(s)}e.productList=a})},getCartList:function(){var t=this;this.$http({method:"post",url:s.a.getCartList+"?memberId="+this.userId}).then(function(i){for(var e=JSON.parse(i.data),c=0,a=0;a<e.length;a++){c+=e[a].Count}0!=c&&(t.carnumFlag=!0,t.carnum=c)})},carClick:function(){this.$router.push("/component/shopcar")},jump:function(t,i){this.$router.push({path:"/component/shopdetail",query:{ProductType:t,ProductId:i}})},imgList:function(){this.img1="../../static/credit/topc.png",this.img2="../../static/credit/botc.png",this.img3="../../static/credit/topc.png",this.img4="../../static/credit/botc.png"},priceClick:function(){1==o?(this.imgList(),this.img2="../../static/credit/botr.png",o=2,r=0,this.getProductList(2,0)):2!=o&&0!=o||(this.imgList(),this.img1="../../static/credit/topr.png",o=1,r=0,this.getProductList(1,0))},saleClick:function(){1==r?(this.imgList(),this.img4="../../static/credit/botr.png",r=2,o=0,this.getProductList(0,2)):2!=r&&0!=r||(this.imgList(),this.img3="../../static/credit/topr.png",r=1,o=0,this.getProductList(0,1))}},mounted:function(){this.imgList(),this.userData=a.a.get("WeiXinUser",function(t){for(var i=t.split("&"),e={},c=0;c<i.length;c++){var a=i[c].split("=");e[a[0]]=a[1]}return e}),this.userId=this.userData.UserId,this.categoryId=this.$route.query.categoryId,1e3==this.categoryId?t("title").html("读书一角"):1001==this.categoryId?t("title").html("试用专区"):1002==this.categoryId?t("title").html("活动名额"):1003==this.categoryId?t("title").html("后厨物料"):1004==this.categoryId?t("title").html("健康美味"):1005==this.categoryId&&t("title").html("生活用品"),this.getMemberById(),this.getCartList()}}}).call(i,e(38))},1146:function(t,i,e){"use strict";var c=function(){var t=this,i=t.$createElement,c=t._self._c||i;return c("div",{staticClass:"readlist"},[c("div",{staticClass:"read_top"},[c("div",{on:{click:t.priceClick}},[t._v("价格"),c("img",{staticClass:"topImg",attrs:{src:t.img1}}),c("img",{staticClass:"botImg",attrs:{src:t.img2}})]),t._v(" "),c("div",{on:{click:t.saleClick}},[t._v("销量"),c("img",{staticClass:"topImg",attrs:{src:t.img3}}),c("img",{staticClass:"botImg",attrs:{src:t.img4}})])]),t._v(" "),c("div",{staticClass:"shoplist"},t._l(t.productList,function(i,a){return c("div",{key:a,staticClass:"shop_box",on:{click:function(e){t.jump(i.ProductType,i.ProductId)}}},[c("div",{staticClass:"shopImgDiv"},[c("img",{attrs:{src:i.ImgUrl}})]),t._v(" "),c("p",[t._v(t._s(i.ProductName))]),t._v(" "),c("p",{staticClass:"money"},[c("span",[t._v(t._s(i.ProductPrice))]),c("img",{attrs:{src:e(538)}})])])})),t._v(" "),c("div",{staticClass:"carIcon",on:{click:t.carClick}},[c("img",{attrs:{src:e(1147)}}),t._v(" "),c("badge",{directives:[{name:"show",rawName:"v-show",value:t.carnumFlag,expression:"carnumFlag"}],attrs:{text:t.carnum}})],1)])},a=[],n={render:c,staticRenderFns:a};i.a=n},1147:function(t,i){t.exports="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGEAAABhCAYAAADGBs+jAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA4ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMTMyIDc5LjE1OTI4NCwgMjAxNi8wNC8xOS0xMzoxMzo0MCAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDpkYWVlMTY2ZC02ZmZjLTQ2NjItYWY1Yy1jMzlhMGNjMTc4NDEiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6QzFCOEQxM0FCNUUwMTFFNzhCNUQ4Rjk3OUU2NEFDNEYiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6QzFCOEQxMzlCNUUwMTFFNzhCNUQ4Rjk3OUU2NEFDNEYiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKE1hY2ludG9zaCkiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpjZTc5ODJlMy00MDBmLTQ3MjktOTE2My02MThhNTQzNzdjYjYiIHN0UmVmOmRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDpjN2UzMmM2ZC1lMTEzLTExNzktOTc3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"},280:function(t,i,e){"use strict";function c(t){e(1141),e(1143)}Object.defineProperty(i,"__esModule",{value:!0});var a=e(1145),n=e(1146),s=e(0),o=c,r=s(a.a,n.a,o,"data-v-634c7a48",null);i.default=r.exports},538:function(t,i){t.exports="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABwAAAAdCAYAAAC5UQwxAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAA4ZpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuNi1jMDY3IDc5LjE1Nzc0NywgMjAxNS8wMy8zMC0yMzo0MDo0MiAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wTU09Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9tbS8iIHhtbG5zOnN0UmVmPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvc1R5cGUvUmVzb3VyY2VSZWYjIiB4bWxuczp4bXA9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC8iIHhtcE1NOk9yaWdpbmFsRG9jdW1lbnRJRD0ieG1wLmRpZDoyZTVlNDY1ZC1kMzNjLTRkMDYtOTY2ZS1mZjU5Njk3ZDU1ZDkiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6MDE1RTdFQURBNDJGMTFFNzhDRDJBQ0ZDMkM0NzBFQkYiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6MDE1RTdFQUNBNDJGMTFFNzhDRDJBQ0ZDMkM0NzBFQkYiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENDIDIwMTUgKE1hY2ludG9zaCkiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDo1ODhhZjUwMy00YWE5LTQ4MmYtOTIwOC1kNDdjZTk5NjAxNzAiIHN0UmVmOmRvY3VtZW50SUQ9ImFkb2JlOmRvY2lkOnBob3Rvc2hvcDo4ZGYzMmJlMS1lN2NmLTExN2EtODI5ZS1kNTc1ZWY2OTYzMWYiLz4gPC9yZGY6RGVzY3JpcHRpb24+IDwvcmRmOlJERj4gPC94OnhtcG1ldGE+IDw/eHBhY2tldCBlbmQ9InIiPz7dFJktAAADDklEQVR42syWe2hOYRzHd9jkssXGXEYmw5qNkShTxCSxcmtK80pN/GPJ/fKHP4VSsjK55I/XSEr4g2garcm9zCgKmfuGpWyZ4fg8Z983x5zz7myi/epznuc973Oe73P5/X7PY9m2HfM/zeo8gmErk+cEyICRojt8hEfwBKrgOrz74/uQHVAwbC3juQ6y2zHws7BT4gEFw1YczwuQq/8OQTk8hjfQAN+gG/SGFBgHi2CGvjGiW4MKnuE5Dw7CFqhvxwyz4CSMhgI4HkTQdmYTstP1uyM+YfqogKl+gl1cdbNc/eQsHbEClZ+iNXIL1kISVCO6T17Zlpnvp8NFOObqx9diXfUkubkZYZFognsKAeP6XyABhsAIcK/GCciDgUEFTYw9Ze0XMMMp1FfBTJgkvKxaIVGsAZmNGxNU0NgAuXQlopV6Z8IgGYZCPNRBjRLAbw4IJQqlwIINHm2+wivhtkRYCdOUkfpr6YfDQgZ8iYEfbSssHtAoK0BYbIJdrTz8tSaQ4npv3s2mz/teXlrvOEHYKoYeUcTyJFbhdNYyM5OlUmGw+jSzXKEtuukXFs0qV0Mj7FfmSZdnRmy+ygMKhzqP4H/GrI5QXpUzei7pD55XwDTcDqM8Zpep/Fmq37fgnE4Ps0JdFRbZCqtYJ8xCdh8vp7Gc0YXsUqfDsDWWMkd5cpg6+q7Ebew8zIGJPkv/El7A+GheGueqV4nWtl7lXOgJk7V3fbUtdY63huzbDLqQ+uFogs0B0lkkdMwxdln4WW60XBrjLE/YSmhDsFFlGeyGWZCmpU5WpsmnHzOQJfDZb4aFcphaGq+lPAUfPATjVb6FjSImyj4m+l8xwtZynu7scAPuavPNKXAaNsA27VuqMk2a4rFZwf5QbZfCHvbTinanMUsTUtpqnYhz5PIlEqvxnZs5gMPWXmprogv+Eo6cICZpD9IelStMrmnWRR63tkimyYcdzp6H7F5BBf1ssy5METPx+Vxh4j4P3yuX3vlbwRjdCBZrmTOc60mLcI3OyTJdppo66c37H9lPAQYA99v64Z0Q3/QAAAAASUVORK5CYII="}});