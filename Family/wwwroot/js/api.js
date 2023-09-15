class Api {
  static dom = "https://localhost:7105/api/tree/";
  ins(treeId, mbrId, x, y) {
    post(`${Api.dom}ins`, {
      treeId: treeId,
      mbrId: mbrId,
      x: x,
      y: y
    })
    .then(res => {
      log(res.status)
      if (res.ok)
        return res.json();
    })
    .then(bdy => log(bdy));
  }
  upd(id, x, y) {
    post(`${Api.dom}upd`, {
      id: id,
      x: x,
      y: y
    })
    .then(res => console.log(res.statusText))
  }
}