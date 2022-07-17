class Art {
   constructor(ctx, width, height, x, y) {
      this.ctx = ctx;
      this.width = width;
      this.height = height;
      this.x = x;
      this.y = y;
   }
   draw() {
      this.ctx.beginPath();
      this.ctx.rect(this.x, this.y, this.width, this.height);
      this.ctx.strokeStyle = "purple";
      this.ctx.stroke();
   }
}
class Member extends Art {
   constructor(ctx, width, height, x, y, name) {
      super(ctx, width, height, x, y);
      this.name = name;
   }
   draw() {
      super.draw();
      ctx.beginPath();
      ctx.font = "18px Arial";
      ctx.fillText(this.name, 5+this.x, 20+this.y);
   }
}

var canvas = document.getElementById("tree");
var ctx = canvas.getContext("2d");
var w = 150; var h = 80;
var member1 = new Member(ctx, w, h, 10, 10, 'Ron');
member1.draw();
var member2 = new Member(ctx, w, h, 210, 10, 'Linda');
member2.draw();
var member3 = new Member(ctx, w, h, 110, 160, 'Casey');
member3.draw();