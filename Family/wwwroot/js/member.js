class Member {
  constructor(x, y, name, itmId, mbrId) {
    this.x = x;
    this.y = y;
    this.name = name;
    this.itmId = itmId;
    this.mbrId = mbrId;
  }
  draw(doc) {
    var isNew = (this.itmId == 0);
    if (isNew)
      this.itmId = this.getTmpItmId();

    var div = doc.createElement('div');
    div.style.left = this.x + 'px';
    div.style.top = this.y + 'px';
    div.atr('class', 'member');
    div.atr('draggable', 'true');
    div.atr('ondragstart', 'drag(event)');
    div.atr('data-itmId', this.itmId);
    div.atr('data-mbrId', this.mbrId);
    if (!isNew) {
      div.atr('ondblclick', 'dblclick(event)');
      div.atr('title', 'Double click to edit');
    }

    var span = doc.createElement('span');
    span.innerText = this.name;
    div.appendChild(span);

    var ᵉtree = ꙩ('#tree');
    ᵉtree.appendChild(div);
  }

  getTmpItmId() {
    var tmp = 999999;
    var exists = false;
    do {
      tmp++;
      exists = ꙩ(`[data-itmId="${tmp}"]`) != null;
      if (tmp > 1100000)
        throw new Error("Temporary id generation for new tree item failed");
    } while (exists);
    return tmp;
  }
}