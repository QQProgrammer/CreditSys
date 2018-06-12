<template>
  <div class="shop">
    <!--轮播-->
  	<swiper auto :list="bannerList" v-model="bannerIndex" dots-position='center' :show-desc-mask=false height="194px"></swiper>
    <!--公告-->
    <div class="shopnotice">
	    <cell>
	    	<img slot="icon" width="20" style="display:block;margin-right:5px;" :src="noticeImg">
	      <marquee>
	        <marquee-item  v-for="(item,index) in noticeList" :key="index" class="align-center">公告:{{item}}</marquee-item>
	      </marquee>
	    </cell>
    </div>
    <!--图标-->
    <div class="shopbtn">
    	<span class="new_style">NEW</span>
	    <grid :cols="3">
	      <grid-item v-for="(item,index) in iconBtnList" :key="index" :label="item.title">
	        <img slot="icon" :src="item.img" @click='jumplist(item.categoryId)'>
	      </grid-item>
	    </grid>
    </div>
    <!--商品列表-->
    <div class="shop_list" v-for="(item,index) in productList">
    	<cell :title="item.CategoryName" value='更多' @click.native="jumplist(item.CategoryId)" style="background: url('../../static/credit/sx.png') no-repeat 14px center;background-size:3px 15px ;"></cell>
    	<div class="scroller-box">
		    <div class="modify-scroller">
		      <div class="shop-box">
		        <div class="shop-item" v-for="(item,index) in item.product" :key="index" @click="jumpdetail(item.ProductId,item.ProductType)">
		        	<div class="shop-img" v-bind:style="{background:'url('+item.ImgUrl+') no-repeat center',backgroundSize:'101% 101%'}"></div>
		        	<p>{{item.ProductName}}</p>
		        	<span class="money">{{item.ProductPrice}}</span><img src="../../static/credit/money.png" class="moneyImg"/>
		        </div>
		      </div>
	  	   </div>
		    <div class="mask-scroller"></div>
      </div>
    </div>
    
    
  </div>
</template>

<script>
	import { Swiper, Cell, Marquee, MarqueeItem, Grid, GridItem,Scroller,cookie } from 'vux'
	import apiUrl from '../apiUrls.js'
	
	export default{
		components:{
			Swiper,
			Cell,
			Marquee,
			MarqueeItem,
			Grid, 
			GridItem,
			Scroller,
			cookie
		},
		data(){
			return{
				userData:{},
				userId:'',
//				hotelProvinceId:'',//用户酒店地址省份
				bannerIndex:0,
				bannerList:[],
				userType:'',
				noticeList:['因上合峰会影响，青岛地区快递将延期寄出','您的老朋友《千滋百味》已上线，火热预售中！'],
				noticeImg:'../static/credit/notice.png',
				iconBtnList: [{
				  categoryId:1001,
				  img: '../static/credit/sy_btn.png',
				  title: '试用专区'
				},{
				  categoryId:1000,
				  img: '../static/credit/ds_btn.png',
				  title: '读书一角'
				},{
				  categoryId:1002,
				  img: '../static/credit/hd_btn.png',
				  title: '活动名额'
				}, {
				  categoryId:1003,
				  img: '../static/credit/hc_btn.png',
				  title: '后厨物料'
				}, {
				  categoryId:1004,
				  img: '../static/credit/jk_btn.png',
				  title: '健康美味'
				},{
				  categoryId:1005,
				  img: '../static/credit/sh_btn.png',
				  title: '生活用品'
				}],
				productList:[]//产品列表
			}
		},
		methods:{
			getShopingBanner(){
				var _this=this;
	  		this.$http({
	  			method:'get',
	  			url:apiUrl.getShopingBanner
	  		}).then(function(response){
	  			var data=JSON.parse(response.data);
	  			for(let i in data){
	  				var item={
	  					url:data[i].Link,
						  img:data[i].PicUrl
	  				}
	  				_this.bannerList.push(item);
	  			}
	  		})
			},
			jumplist(categoryId){//跳转到商品列表
				if(categoryId!=1002){
					this.$router.push({path:'/component/readlist',query:{categoryId:categoryId}})
				}else{
					this.$router.push({path:'/component/expect',query:{shop:0}})
				}
			},
			jumpdetail(productId,productType){//跳转到商品详情
				this.$router.push({path:'/component/shopdetail',query:{ProductId:productId,ProductType:productType}})
			},
//			getMemberById(){//获取简历信息
//	  		var _this=this;
//				var params={
//				  'MemberId':this.userId
//				}
//				this.$http({
//					method:'POST',
//					url:apiUrl.getMemberById,
//					data:params
//				}).then(function(response){
//					var data=JSON.parse(response.data);
//					if(data.length!=0){
//						var userinfo=data[0];
//						_this.hotelProvinceId=userinfo.ProvinceId;
//						_this.getProductList();//获取商品列表
//					}
//			  })
//			},
			getProductList(){//获取商品列表
				var _this=this;
				var params={
			    "productType":0,
					"categoryId":0,
					"productName":'',
					"PageSize" :999,
					'IndexPage':1,
					"priceOD"  :0,
				  "saleOD"   :0
			  }
	  		this.$http({
	  			method:'post',
	  			url:apiUrl.getProductList,
	  			data:params
	  		}).then(function(response){
	  			var data=JSON.parse(response.data);
	  			var productList=data.data;
//	  			console.log(productList);
	  			var productArr=[];
//	  			if(_this.userType==2){//会员
//          for(var i=0;i<productList.length;i++){//判断商品销售区域  0是全部省份
//		  				var prolist=productList[i];
//		  				if(prolist.SaleProvince!='0'){
//								if(prolist.SaleProvince.indexOf('|')==-1){//单个省份
//									prolist.SaleProvince=parseInt(prolist.SaleProvince);
//									if(prolist.SaleProvince==_this.hotelProvinceId){//显示此商品
//			                productArr.push(prolist);
//									}
//								}else{
//									var saleArr=prolist.SaleProvince.split('|');
//								  for(var j=0;j<saleArr.length;j++){
//								  	var sale=saleArr[j];
//								  	sale=parseInt(sale);
//								  	if(sale==_this.hotelProvinceId){
//								  		productArr.push(prolist);
//								  	}
//								  }
//							  } 
//		  				}else if(prolist.SaleProvince=='0'){//0 全部省份
//		  					productArr.push(prolist);
//		  				}
//		  			}
//	  			}else if(_this.userType==1||_this.userType==0){
	  				productArr=productList;
//	  			}
	  			
           var Product=[];//1000
	       	 var Product1=[];//1001
	       	 var Product2=[];//1002
	       	 var Product3=[];//1003
	       	 var Product4=[];//1004
	       	 var Product5=[];//1005
           for(var i=0;i<productArr.length;i++){
           	 var productlist=productArr[i];
//		  			 productlist.ImgUrl=productlist.ImgUrl.replace('Product','SmallProduct');//更换图片地址
           	 var item={
	       	 	 	 ImgUrl:productlist.ImgUrl,
	       	 	 	 ProductId:productlist.ProductId,
	       	 	 	 ProductType:productlist.ProductType,
	       	 	 	 ProductName:productlist.ProductName,
	       	 	 	 ProductPrice:productlist.ProductPrice
           	 }
           	 if(productlist.CategoryId==1000){
           	 	 Product.push(item);
           	 }else if(productlist.CategoryId==1001){
           	 	 Product1.push(item);
           	 }else if(productlist.CategoryId==1002){
           	 	 Product2.push(item);
           	 }else if(productlist.CategoryId==1003){
           	 	 Product3.push(item);
           	 }else if(productlist.CategoryId==1004){
           	 	 Product4.push(item);
           	 }else if(productlist.CategoryId==1005){
           	 	 Product5.push(item);
           	 }
           }
           _this.productList=[{
           	 CategoryId:1001,
           	 CategoryName:'试用专区',
           	 product:Product1
           },{
           	 CategoryId:1000,
           	 CategoryName:'读书一角',
           	 product:Product
           },{
           	 CategoryId:1003,
           	 CategoryName:'后厨物料',
           	 product:Product3
           },{
           	 CategoryId:1004,
           	 CategoryName:'健康美味',
           	 product:Product4
           },{
           	 CategoryId:1005,
           	 CategoryName:'生活用品',
           	 product:Product5
           }]
//         console.log(_this.productList);
	  		})
			}
		},
		mounted(){
			this.userData=cookie.get('WeiXinUser',function(val){
  		  var a = val.split("&");
				var obj = {};
				for (var i = 0; i < a.length; i++) {
					var b = a[i].split("=");
					obj[b[0]] = b[1];
				}
				return obj;
  	  }) 
	    this.userId=parseInt(this.userData.UserId);
	    this.userType=parseInt(this.userData.UserType);
	    this.getProductList();//获取商品列表
	    this.getShopingBanner();//轮播图
		}
	}
</script>

<style scoped>
  .shopnotice{background: #f9f9f9;}
  .shopnotice .align-center{font-size:13px;color:#3E3E3E;text-align: left;} 
  .shopbtn{position: relative;}
  .new_style{width: 10%;line-height: 18px;display: inline-block;background: #E83428;border-radius: 25px;color: #fff;font-size: 12px;text-align: center;position: absolute;
            left: 19%; top: 10%;z-index: 100;-webkit-animation:newcss 0.6s ease-in-out infinite alternate;}
   @media screen and (max-width:370px ) {
  	.shopnotice .align-center{font-size:11px;} 
  	.shopnotice .weui-cell{padding: 10px 0 10px 6px;}
  	.new_style{font-size: 10px;}
  }          
	@-webkit-keyframes newcss{
		  0% {
		    -webkit-transform: scale(1);   
	    }
	    100% {
		    -webkit-transform: scale(0.8);   
	    }
	}
   
  /*图标*/
  .shopbtn{margin-bottom: 10px;}
  /*商品列表*/
  .shop_list{width:100%;border-top: 5px solid #f8f8f8;}
  
  .shop-box{ width: 1000px; height: 210px; position: relative; overflow: hidden; }
	.shop-item{display: inline-block; margin-left: 10px;}
	.shop-img{width: 155px; height: 155px;}
	.shop-item:last-child{ margin-right: 15px; }
	.shop-item {font-size: 13px;color: #3E3E3E;}
	.shop-item p{margin-top: 10px;font-size: 12px;}
	.shop-item .money{margin-right: 4px;color: #e10505;}
	.shop-item .moneyImg{width: 15px;position: relative;top: 3px;}
</style>
<style>
  #vux_view_box_body{background: #fff;}
  /*公告*/
  .shopnotice .vux-cell-primary{flex:0 !important;}
  .shopnotice .weui-cell{padding: 10px 0 10px 8px;}
  /*图标*/
  .shop .weui-grid__label {color: #3e3e3e !important;font-size: 12px !important;}
  .shop .weui-grid__icon{width: 35px !important;height: 35px !important;}
  .shop .weui-grid{padding: 20px 10px 0 10px !important;}
  .shop .weui-grids:after{content: none !important;}
  .shop .weui-grids:before{content: none !important;}
  .shop .weui-grid:after{content: none !important;}
  .shop .weui-grid:before{content: none !important;}
  /*商品列表*/
  .shop_list .vux-label{font-size: 14px !important;color: #3E3E3E;text-indent: 2% !important;}
  .shop_list .weui-cell__ft{font-size: 12px !important;}
  .shop_list .scroller-box { position: relative; }
	.shop_list .scroller-box .mask-scroller { width: 100%;position: absolute; left: 0; bottom: 0; background: red; }
	.shop_list .scroller-box .modify-scroller { overflow: auto; }
	.shop_list .scroller-box .modify-scroller { overflow-x: visible; }
	.shop_list .scroller-box .modify-scroller::-webkit-scrollbar { display: none; }
	.shop_list .scroller-box .modify-scroller:horizontal { display: none; }
	.shop_list .weui-cell__ft:after {content: " ";display: inline-block;height: 6px;width: 6px; border-width: 1px 1px 0 0;border-color: #C8C8CD;border-style: solid;
    transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);position: relative;top: -2px;right: 2px;}

</style>