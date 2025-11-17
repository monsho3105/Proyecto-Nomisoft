// Load nominas with Estado = "Por liquidar" and render a table into #resultadoAvanzado
async function loadNominas() {
  try {
    const estado = encodeURIComponent('Por liquidar');
    const res = await fetch(`/api/nominas?estado=${estado}`);
    if (!res.ok) { console.error('API error', res.status, res.statusText); return; }
    const list = await res.json();
    const container = document.getElementById('resultadoAvanzado') || document.getElementById('resultadoNominas');
    if (!container) return;

    if (!Array.isArray(list) || list.length === 0) {
      container.innerHTML = '<p>No hay nóminas por liquidar.</p>';
      return;
    }

    let html = '<table class="table"><thead><tr><th>Documento</th><th>Periodo</th><th>Neto</th></tr></thead><tbody>';
    list.forEach(n => {
      const neto = n.Neto_Pagar != null ? Number(n.Neto_Pagar).toLocaleString() : '';
      html += `<tr><td>${escapeHtml(n.Numero_Documento)}</td><td>${escapeHtml(n.Periodo)}</td><td style="text-align:right">${escapeHtml(neto)}</td></tr>`;
    });
    html += '</tbody></table>';
    container.innerHTML = html;
  } catch (err) {
    console.error('Failed to load nominas', err);
  }
}

function escapeHtml(s) {
  if (s == null) return '';
  return String(s).replace(/[&<>"']/g, m => ({'&':'&amp;','<':'&lt;','>':'&gt;','"':'&quot;',"'":'&#39;'}[m]));
}

document.addEventListener('DOMContentLoaded', loadNominas);