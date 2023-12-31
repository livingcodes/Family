class Sel {
  constructor(doc, container) {
    this.doc = doc;
    this.container = container;
    this.div = null;

    this.start = { x: 0, y: 0 };
    this.end = { x: 0, y: 0 };
    this.isSelecting = false;
  }

  width() { return this.end.x - this.start.x; }
  height() { return this.end.y - this.start.y; }
  left() {
    if (this.width() < 0)
      return this.end.x;
    else
      return this.start.x;
  }
  top() {
    return (this.height() < 0)
      ? this.end.y
      : this.start.y;
  }

  draw(doc) {
    return this.drawSelBox();
  }

  drawSelBox() {
    var existed = true;
    if (!this.div) {
      existed = false;
      this.div = this.doc.createElement('div');
      this.div.atr("id", "sel");
      this.div.atr("class", "sel");
    }
    this.div.style.left = this.left() + 'px';
    this.div.style.top = this.top() + 'px';
    this.div.style.width = Math.abs(this.width()) + 'px';
    this.div.style.height = Math.abs(this.height()) + 'px';
    

    if (this.isSelecting)
      this.div.style.borderColor = "lightblue";
    else
      this.div.style.borderColor = "yellow";

    if (!existed)
      this.container.appendChild(this.div);
    return this.div;
  }

  onStart(e) {
    this.isSelecting = true;
    // todo: if over member then exit
    log(`mouse down: offset x=${e.offsetX}, y=${e.offsetY}`);
    log(e);
    this.start.x = e.offsetX;
    this.start.y = e.offsetY;
  }

  onMove(e) {
    if (!this.isSelecting)
      return;

    if (e.target == this.container) {
      log("target is container");
      this.end.x = e.offsetX;
      this.end.y = e.offsetY;
    } else {
      this.end.x = e.target.style.left.rem("px").num() + e.offsetX;
      this.end.y = e.target.style.top.rem("px").num() + e.offsetY;
    }

    log(`mouse move: isSelecting=${this.isSelecting}, x=${this.end.x}, y=${this.end.y}`);
    log(e);
    this.draw();
  }

  onEnd(e) {
    this.isSelecting = false;
    log(`mouse up: x:${e.offsetX}, y:${e.offsetY}`);
    log(e);

    if (e.target == this.container) {
      this.end.x = e.offsetX;
      this.end.y = e.offsetY;
    } else {
      this.end.x = e.target.style.left.rem("px").num() + e.offsetX;
      this.end.y = e.target.style.top.rem("px").num() + e.offsetY;
    }

    this.draw();
  }
}