class Member {
  constructor(x, y, name, itmId, mbrId) {
    this.x = x;
    this.y = y;
    this.name = name;
    this.itmId = itmId;
    this.mbrId = mbrId;
  }
  draw(doc) {
    var div = doc.createElement('div');
    div.style.left = this.x + 'px';
    div.style.top = this.y + 'px';
    div.atr('class', 'member');
    div.atr('draggable', 'true');
    div.atr('ondragstart', 'drag(event)');
    div.atr('ondblclick', 'dblclick(event)');
    div.atr('data-itmId', this.itmId);
    div.atr('data-mbrId', this.mbrId);

    var span = doc.createElement('span');
    span.innerText = this.name;
    div.appendChild(span);

    var ᵉtree = ꙩ('#tree');
    ᵉtree.appendChild(div);
  }
}