using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookkeepingAPI.Models;

namespace bookkeepingAPI.Controllers
{
    public class TodoItemsController : Controller
    {
        private readonly bkcontext _context;

        public TodoItemsController(bkcontext context)
        {
            _context = context;
        }

        // GET: TodoItems
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.TodoItems.ToListAsync());
        }

        // GET: TodoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItems = await _context.TodoItems
                .FirstOrDefaultAsync(m => m.item_id == id);
            if (todoItems == null)
            {
                return NotFound();
            }

            return Ok(todoItems);
        }

        // GET: TodoItems/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // POST: TodoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("item_id,item_name")] TodoItems todoItems)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoItems);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(todoItems);
        }

        // GET: TodoItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItems = await _context.TodoItems.FindAsync(id);
            if (todoItems == null)
            {
                return NotFound();
            }
            return Ok(todoItems);
        }

        // POST: TodoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("item_id,item_name")] TodoItems todoItems)
        {
            if (id != todoItems.item_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoItems);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoItemsExists(todoItems.item_id))
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
            return Ok(todoItems);
        }

        // GET: TodoItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoItems = await _context.TodoItems
                .FirstOrDefaultAsync(m => m.item_id == id);
            if (todoItems == null)
            {
                return NotFound();
            }

            return Ok(todoItems);
        }

        // POST: TodoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoItems = await _context.TodoItems.FindAsync(id);
            _context.TodoItems.Remove(todoItems);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoItemsExists(int id)
        {
            return _context.TodoItems.Any(e => e.item_id == id);
        }
    }
}
