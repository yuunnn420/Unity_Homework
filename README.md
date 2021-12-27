# Environment
Unity 2020.3.21f1 (LTS)

# How to use (play) your game
A向左轉，D向右轉，Space跳

# Your game
吃到一個金幣加一分，多存活一秒加一分
如果撞到障礙物(會被敵人抓到)或掉下去就GAMEOVER，按右上角的按鈕可以返回menu
animation的部分因為會一直往前跑的關係，寫的是run<->jump , GAMEOVER的時候才會idle

# Bonus
Infinite ground spawner:
路有時候會變窄，隨機靠左邊或右邊。
地圖可以無限生成，且不會與舊地圖重疊。

Music:
有三首美麗動人的音樂串燒循環撥放

A good game structure design (code):
player, coin, dragon都有自己的controller，沒有都塞在一起。

player用的是character controller，但裡面的isgrounded判定不夠準確，所以寫自己用raycast寫function來判定。
bool IsGrounded()
{
    return Physics.Raycast(transform.position, Vector3.down, margin);
}

使用character controller的move讓player會自己往前跑
controller.Move(transform.forward * speed * Time.deltaTime);

因為使用character controller的關係不能用rigidbody，所以自己寫gravity。
playerVelocity.y += Physics.gravity.y * Time.deltaTime;

Some special game objects which aren’t mentioned above:
死掉會顯示gameover。
menu的how to play按鈕會切到另一個canvas，按另一個canvas的back即可返回。
dragon的動畫，在追player的時候會飛，追到的話會攻擊。

How good your game is:
金幣會旋轉，而且金幣的生成會在地板的左邊、右邊或中間。
遊戲中偶爾會看到龍可愛的耳朵(有特別設計)。
如果是撞到障礙物會被龍追到，而且龍會有攻擊的動畫，掉下去的話不會。
player跳的時候dragon不會跟著跳，因為dragon是用飛的。
camera有自己的controller，不是放在player裡，有設定delay來避免畫面旋轉太快，玩家來不及反應。
地圖生成有特別設計，轉彎、hole、障礙物這些，要生成都要連續生成一小段直線之後才有機率。

# Feedback
早上好中国
现在我有冰淇淋
我很喜欢冰淇淋
但是
unity課程
比冰淇淋
unityㄎ
unity課程
我最喜欢
所以…现在是音乐时间
准备 1 2 3
两个礼拜以后
unity課程9 ×3
不要忘记
不要错过
记得去資訊系上unity課程
因为非常好課程
差不多一样冰淇淋
再见

# git
https://github.com/yuunnn420/Unity_Homework