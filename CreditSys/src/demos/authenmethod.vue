<template>
  <div class="authenmethod">
    
    <p class="authenmethod-top">请选择认证方式</p>
    <div class="authenmethod-wrap">
    	<div @click="jump('smrz')">
    		<img src="../../static/credit/authen_a.png"/>
    		<img src="../../static/credit/authen_c.png" class="recomImg"/>
    		<p>实名认证</p>
    	</div>
    	<div @click="jump('/component/authencode')">
    		<img src="../../static/credit/authen_b.png"/>
    		<p>注册码认证</p>
    	</div>
    </div>
    
  </div>
</template>

<script>
import { cookie } from 'vux'
import apiUrl from '../apiUrls.js'

export default{
	components:{
		cookie
	},
	data(){
		return{
			userData:{},
			userId:''
		}
	},
	methods:{
		jump(val){
			if(val=='smrz'){//点击实名认证
	  		this.getMemberAuth();//获取认证信息
			}else{//认证码认证
				this.$router.push(val);
			}
		},
    getMemberAuth(){//获取认证信息 -1不通过 0审核中 1通过 null没有提交过认证信息
				var _this=this;
	  		this.$http({
	  			method:'post',
	  			url:apiUrl.getMemberAuth+'?memberId='+this.userId
	  		}).then(function(response){
	  			var data=JSON.parse(response.data);
	  			if(data==null||data.AuthState==-1){//未认证或认证不通过
						_this.$router.push('/component/authenhotel');
	  			}else if(data.AuthState==0||data.AuthState==1){
						_this.$router.push('/component/authenname');
	  			}
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
	  this.userId=Number(this.userData.UserId);

	}
}
</script>

<style scoped>
.authenmethod{height: 100%;background: #fff;overflow: hidden;}
.authenmethod-top{width: 100%;text-align: center;color: #E83428;margin-top: 5%;}
.authenmethod-wrap{width: 100%;height:90%;border-top: 1px solid #f4f4f4;margin-top: 3%;}
.authenmethod-wrap div{padding: 8% 0;width: 80%;background: #f8f8f8;border-radius: 5px;margin-left: 10%;margin-top: 7%;text-align: center;color: #3e3e3e;font-size: 14px;}
.authenmethod-wrap div p{margin-top: 5px;}
.authenmethod-wrap img{width: 25%;}
.recomImg{width: 6% !important;position: absolute;right: 32%;}
</style>
<style>

</style>