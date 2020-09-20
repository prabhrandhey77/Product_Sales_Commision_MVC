using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Sales_Commision_MVC.Data;
using Product_Sales_Commision_MVC.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Sales_Commision_MVC.Controllers
{
    public class SalesAgentsController : Controller
    {
        private readonly Product_Sales_Commision_MVCContext _context;

        public SalesAgentsController(Product_Sales_Commision_MVCContext context)
        {
            _context = context;
        }

        // GET: SalesAgents
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesAgent.ToListAsync());
        }

        // GET: SalesAgents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesAgent = await _context.SalesAgent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesAgent == null)
            {
                return NotFound();
            }

            return View(salesAgent);
        }
        [Authorize]
        // GET: SalesAgents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesAgents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AgentName,ContactNumber")] SalesAgent salesAgent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesAgent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesAgent);
        }

        // GET: SalesAgents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesAgent = await _context.SalesAgent.FindAsync(id);
            if (salesAgent == null)
            {
                return NotFound();
            }
            return View(salesAgent);
        }
        [Authorize]
        // POST: SalesAgents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AgentName,ContactNumber")] SalesAgent salesAgent)
        {
            if (id != salesAgent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesAgent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesAgentExists(salesAgent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(salesAgent);
        }
        [Authorize]
        // GET: SalesAgents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesAgent = await _context.SalesAgent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salesAgent == null)
            {
                return NotFound();
            }

            return View(salesAgent);
        }

        // POST: SalesAgents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesAgent = await _context.SalesAgent.FindAsync(id);
            _context.SalesAgent.Remove(salesAgent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesAgentExists(int id)
        {
            return _context.SalesAgent.Any(e => e.Id == id);
        }
    }
}
