<template>
  <div class="menu">
     <div v-for="(item,index) in datalist" :key="index" @click="jump(item.link)" class="menuDiv">
     	 <img :src="item.img"/>
     </div>
  </div>
</template>

<script>
//	import { } from 'vux'
//	import apiUrl from '../apiUrls.js'
	
	export default{
		components:{
			
		},
		data(){
			return{
				datalist:[
					{
						img:'../../static/credit/menu_img11.png',
						link:'http://u6879651.viewer.maka.im/k/09NLKVP8?from=singlemessage'
					},
				  {
						img:'../../static/credit/menu_img01.png',
						link:'http://mp.weixin.qq.com/s/7Ps9enYT5Pk9gVNgLE35SQ'
					},
					{
						img:'../../static/credit/menu_img2.png',
						link:'http://mp.weixin.qq.com/s/UvqeutBJi6xAkx-RYnKYGQ'
					},
					{
						img:'../../static/credit/menu_img3.png',
						link:'http://mp.weixin.qq.com/s/Y72soRqRcS7ni1I77kxziw'
					},
					{
						img:'../../static/credit/menu_img4.png',
						link:'http://u476561.viewer.maka.im/k/PQG6BMRK'
					},
					{
						img:'../../static/credit/menu_img5.png',
						link:'http://i.eqxiu.com/s/r9XPnzyh'
					},
					{
						img:'../../static/credit/menu_img6.png',
						link:'https://mp.weixin.qq.com/s?__biz=MjM5MTAyMzgwNA==&mid=201499990&idx=1&sn=f878cf89a94ab450887d2997161725ad#rd'
					},
					{
						img:'../../static/credit/menu_img7.png',
						link:'https://mp.weixin.qq.com/s?__biz=MjM5MDY0NDQzOQ==&mid=2649882398&idx=1&sn=4f918fce17f95e2ab8e169d93e682ae2&chksm=be44fea6893377b0263f0af391a660ff4ba1533f78299c5ed8c573dc2115a7c5afe00ed47296#rd'
					},
					{
						img:'../../static/credit/menu_img8.png',
						link:'https://mp.weixin.qq.com/s?__biz=MjM5MTAyMzgwNA==&mid=200636265&idx=1&sn=cfdd3333e1dbb631e256e41f631910d3#rd'
					},
					{
						img:'../../static/credit/menu_img9.png',
						link:'https://mp.weixin.qq.com/s?__biz=MjM5MTAyMzgwNA==&mid=200619433&idx=1&sn=f17bf242f45022e558f41c63f4571e10#rd'
					},
					{
						img:'../../static/credit/menu_img10.png',
						link:'https://mp.weixin.qq.com/s?__biz=MjM5MDY0NDQzOQ==&mid=2649882258&idx=1&sn=4c0e1fab3b85e7b00a5961d47fe6308e&chksm=be44ff2a8933763c1cf55ce079d127ef5534d828a5abd187671febcbfad64063355b2f62fcda#rd'
					}
				]
			}
		},
		methods:{
			jump(link){
				window.location.href=link;
			}
		},
		mounted(){
			
		}
	}
</script>

<style scoped>
.menuDiv{width: 100%;height:162px;margin-top: 8px;}
.menuDiv img{width: 100%;height: 100%;}
</style>
<style>
#vux_view_box_body{background: #fff;}
</style>